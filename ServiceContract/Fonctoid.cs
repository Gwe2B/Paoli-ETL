namespace ServiceContract
{
     public abstract class Fonctoid
    {
        protected List<string> SrcCols { get; set; }
        protected List<string> OuttCols { get; set; }
        protected abstract void Proceed();
    }
}