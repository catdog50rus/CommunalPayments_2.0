namespace CnD.CommunalPayments.Contracts.Models.Response
{
    public abstract class BaseResponse
    {
        public bool IsSuccess => ErrorCode == 0;

        public string ErrorMessage { get; set; } = string.Empty;

        public int ErrorCode { private get; init; } = 0;
    }
}