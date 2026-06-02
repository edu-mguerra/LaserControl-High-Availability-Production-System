using ReaLTaiizor.Controls;

namespace LaserProduction.Desktop.Helpers
{
    public static class SecurityHelper
    {
        public static void ConfigurarAcesso(string perfil,
            MaterialButton btnRegravar,
            MaterialButton btnTransferir,
            MaterialButton btnUsuarios,
            MaterialButton btnParametros,
            MaterialComboBox cmbFiltroStatus)
        {
            if (perfil == "COMUM")
            {
                if (btnRegravar != null) btnRegravar.Visible = false;
                if (btnTransferir != null) btnTransferir.Visible = false;
                if (btnUsuarios != null) btnUsuarios.Visible = false;
                if (btnParametros != null) btnParametros.Visible = false;

                if (cmbFiltroStatus != null) cmbFiltroStatus.Items.Remove("Finalizado");
            }
        }
    }
}