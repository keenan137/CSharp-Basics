namespace NetCoreConsoleApp.Repositories.Interface
{
    public interface IDivisionService
    {
        void Initialize(double first, double second);
        void DivideAndCastDecimal();
        void DivideAndCastDouble();
        void DivideAndCastFloat();
        void DivideAndCastInt();
        void DivideWithExceptionAndCastDouble();
    }
}
