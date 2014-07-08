
namespace WalletHelper.Entity.Enums
{
    public enum PaymentTypes
    {
        None=0,
        Expense = 1,
        Income = 2
    }

    /// <summary>
    /// Enumeración que indica los filtros para mostrar los movimientos
    /// </summary>
    public enum PaymentValues
    {
        Day = 0,
        Week = 1,
        Month = 2,
        /// <summary>
        /// Trimestre
        /// </summary>
        Quarter = 3,
        Semester = 4,
        Annual = 5
    }
}
