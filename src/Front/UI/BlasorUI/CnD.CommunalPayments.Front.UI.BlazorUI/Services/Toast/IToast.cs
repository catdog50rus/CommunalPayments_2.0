

namespace CnD.CommunalPayments.Front.UI.BlazorUI.Services.Toast
{
    public interface IToast
    {
        (string, string, string) ShowToast(ToastLevel level);
    }
 
}
