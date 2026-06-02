# Sistema de Controle de Produção a Laser 🏭⚡

Um sistema robusto e resiliente de controle de produção focado no chão de fábrica, desenvolvido para gerenciar máquinas de gravação a laser. A arquitetura foi projetada com alta disponibilidade (Offline-First), garantindo que a produção nunca pare, mesmo em cenários de queda de internet.

---

## 🏗️ Arquitetura do Sistema

O projeto foi estruturado utilizando o padrão de arquitetura distribuída e modular, garantindo o desacoplamento de responsabilidades, segurança e escalabilidade:

* **Desktop App (Front-end/Cliente):** Desenvolvido em C# (Windows Forms) utilizando a biblioteca gráfica ReaLTaiizor (Material UI). É o responsável pela interface direta com o operador no chão de fábrica, comunicação via porta Serial (COM) com o hardware da máquina laser e gestão do banco de dados de contingência local.
* **Web API (Back-end/Servidor):** Camada intermediária REST responsável por centralizar as regras de negócio complexas da produção, aplicar hashing seguro de senhas com `BCrypt` e proteger as credenciais de acesso direto à infraestrutura principal.
* **LaserProduction.Shared (Camada de Compartilhamento):** Biblioteca de classes (`Class Library`) que centraliza as entidades de domínio, objetos de transferência de dados (DTOs como `UsuarioDto`, `NovaProducaoDto`, `ProducaoOffline`) e validações comuns. É referenciada tanto pelo projeto Desktop quanto pela Web API, garantindo consistência total nos contratos de dados trafegados.
* **MySQL (Banco de Dados Principal):** Servidor centralizado (hospedado na nuvem ou rede local) que armazena o estado global e histórico de auditoria do sistema (Usuários, Produções, Máquinas, Logs).
* **SQLite (Banco de Dados Local):** Atua como um "cofre de emergência" na máquina local do operador (`producao_offline.db`), mantendo a fila de TAGs de produção retidas de forma resiliente em cenários de isolamento de rede.

---

## ✨ Principais Funcionalidades

* **Gestão de Produção em Tempo Real:** Painel com indicadores dinâmicos (Aguardando Início, Em Andamento, Finalizados).
* **Filtros Inteligentes:** Buscas combinadas por Pedido, Cliente, TAG, Status, Usuário e Período de Data.
* **Controle de Acesso (RBAC):** Níveis de permissão distintos entre Administradores (Master) e Operadores Comuns.
* **Integração de Hardware:** Envio de comandos diretos via Serial Port para queima a laser, com Modo Simulador inteligente embutido.
* **Regravação:** Função para reenviar o comando de queima sem duplicar registros no banco de dados.
* **Exportação de Dados:** Geração de relatórios nos formatos XML, Excel (.xlsx) e LibreOffice Calc (.ods).

---

## 🧠 Regras de Negócio & Fluxos Críticos

### 1. Transferência de Produção entre Máquinas
O sistema modela a realidade do chão de fábrica. Quando uma produção é transferida da "Máquina 1" para a "Máquina 2":
* O sistema tira a TAG da fila da primeira máquina e aloca na fila da segunda.
* O status permanece estritamente como **"AGUARDANDO INÍCIO"**.
* **Regra Operacional:** A transferência apenas move a peça fisicamente/logicamente de lugar. O operador da nova máquina deve ir ao sistema e iniciar o processo manualmente (mudando o status para "EM ANDAMENTO") para garantir o rastreio correto de tempo e responsabilidade.

### 2. O Sincronizador Automático (Guardião Offline)
Para garantir que a fábrica não dependa da estabilidade da rede, o sistema possui uma rotina silenciosa de auto-recuperação (Offline-First). O fluxo funciona em 4 etapas:

1.  **O Verificador:** A cada 60 segundos (utilizando um `System.Windows.Forms.Timer`), o sistema tenta um "ping" na API.
2.  **A Sincronização:** Se o ping responder confirmando que a internet voltou, o sistema lê o arquivo local `producao_offline.db` (SQLite).
3.  **O Envio:** O sincronizador resgata cada linha de produção que ficou retida e tenta enviar a carga de dados para a API (MySQL).
4.  **A Limpeza:** Se a API processar com sucesso e retornar um `Status 200 OK`, o sistema deleta o registro do SQLite, esvaziando a fila local progressivamente.

### 3. Segurança e Auditoria
* **Criptografia de Senhas:** Nenhuma senha é trafegada ou salva em texto plano. O sistema utiliza `BCrypt` na API para converter as senhas em Hash antes da persistência.
* **Edição Segura:** Ao editar um usuário na tela de gerenciamento, a senha antiga nunca é revelada para o operador master.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (.NET)
* **UI Framework:** Windows Forms + ReaLTaiizor (Material UI)
* **Comunicação:** `HttpClient` (REST API), `System.IO.Ports.SerialPort`
* **Bancos de Dados:** MySQL (Server) e SQLite (Local via `Microsoft.Data.Sqlite`)
* **Serialização:** `System.Text.Json`

---

## 🚀 Como Executar o Projeto

1.  Configure a string de conexão do MySQL na Web API.
2.  Inicie a Web API e anote o IP/Porta onde ela está hospedada.
3.  No projeto Desktop, configure a URL base da API no `ProducaoService`.
4.  O banco local (`producao_offline.db`) será criado automaticamente na primeira execução do programa caso não exista.
5.  *(Opcional)* Conecte a placa da máquina laser via USB e configure a porta (ex: `COM3`) na tela de Parâmetros. Caso não haja hardware, o sistema entrará automaticamente em **Modo Simulação**.

---

## 🚀 Como Iniciar o Projeto (Passo a Passo)

Para rodar este projeto na sua máquina de desenvolvimento ou prepará-lo para produção, siga as etapas abaixo:

### 📋 Pré-requisitos
* **Visual Studio 2022** (ou superior) com o workload de "Desenvolvimento para Desktop .NET" e "Desenvolvimento Web e ASP.NET" instalados.
* **.NET SDK** (versão 6.0 ou superior, dependendo da configuração do projeto).
* **MySQL Server** rodando localmente (localhost) ou em um servidor remoto.

---

### Passo 1: Configuração Automática do Banco de Dados
O sistema possui uma rotina de inicialização inteligente (Auto-Migration/Seed). **Não é necessário executar scripts SQL ou criar tabelas manualmente.**
1. Certifique-se apenas de que o seu servidor MySQL está em execução.
2. O banco de dados, toda a estrutura de tabelas e o primeiro usuário administrador (**Login: `admin` / Senha: `123456`**) serão criados de forma totalmente automática pela API assim que ela for executada pela primeira vez.

---

### Passo 2: Iniciando o Back-end (Web API)

1. Navegue até a pasta da API do projeto e abra a solução (`.sln`) no Visual Studio.
2. Abra o arquivo `appsettings.json` e localize a seção `ConnectionStrings`.
3. Altere a string de conexão para apontar para o seu servidor MySQL (o banco de dados será criado automaticamente caso não exista):

```json
{
  "ConnectionStrings": {
    "MySqlConnection": "Server=localhost;Database=laser_producao_db;User=root;Password=sua_senha;"
  }
}
```

4. Clique com o botão direito na solução e selecione **Restaurar Pacotes NuGet**.
5. Execute o projeto da API (**F5**).

No primeiro arranque, a API irá:

- Conectar-se ao servidor MySQL;
- Criar automaticamente o banco de dados;
- Criar todas as tabelas necessárias;
- Executar as migrações pendentes;
- Inserir automaticamente os dados iniciais necessários para o funcionamento do sistema.

6. Anote a URL base gerada no navegador ou console.

Exemplo:

```text
https://localhost:5001
```

---

### Passo 3: Iniciando o Front-end (Desktop App)

1. Abra a solução do projeto Desktop (Windows Forms) no Visual Studio.
2. Localize onde a URL da API está configurada (por exemplo: `ProducaoService.cs` ou uma classe de configuração).
3. Substitua a URL existente pela URL anotada no Passo 2.
4. Restaure os pacotes NuGet do projeto Desktop.
5. Compile a solução:

```text
Ctrl + Shift + B
```

6. Execute o projeto:

```text
F5
```

---

### Passo 4: Primeiro Acesso

Utilize as credenciais de acesso cadastradas no ambiente ou fornecidas pelo administrador responsável pela implantação.

### Banco Offline

Após o primeiro acesso, o sistema criará automaticamente o banco local SQLite:

```text
producao_offline.db
```

Este arquivo será armazenado na mesma pasta do executável e funcionará como mecanismo de contingência para preservar os dados em caso de falha de rede ou indisponibilidade da API.

### Configuração da Máquina Laser

Acesse a tela **Parâmetros** para configurar:

- A Porta COM utilizada pela máquina Laser;
- Ou manter a configuração padrão para operar em **Modo Simulação**.

---

### Resumo Rápido

#### Back-end

- Iniciar o MySQL;
- Configurar o `appsettings.json`;
- Restaurar os pacotes NuGet;
- Executar a API (F5);
- Anotar a URL da API.

#### Front-end

- Abrir o projeto Desktop;
- Configurar a URL da API;
- Restaurar os pacotes NuGet;
- Compilar (Ctrl + Shift + B);
- Executar (F5).

#### Recursos Automáticos

✅ Criação automática do banco MySQL  
✅ Execução automática das migrações  
✅ Criação automática das tabelas  
✅ Carga automática de dados iniciais (Seed)  
✅ Criação automática do banco SQLite offline  
✅ Suporte ao Modo Simulação da máquina Laser

## 📺 Demonstração em Vídeo

Clique na imagem abaixo para assistir ao funcionamento do sistema em tempo real:

[![Sistema de Controle de Produção a Laser](https://i.ytimg.com/vi/62wg7EepQGs/maxresdefault.jpg)](https://www.youtube.com/watch?v=62wg7EepQGs)

*Desenvolvido para garantir máxima estabilidade e rastreabilidade na indústria de gravação.*
