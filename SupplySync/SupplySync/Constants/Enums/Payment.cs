namespace SupplySync.Constants.Enums
{
    public enum PaymentMethod
    {
        NEFT = 1,
        RTGS = 2,
        IMPS = 3,
        Cheque = 4,
        UPI = 5
    }

    public enum PaymentStatus
    {
        Initiated = 1,
        Success = 2,
        Failed = 3,
        Reversed = 4
    }
}
