namespace ServiceContract
{
     public abstract class Fonctoid
    {
        public List<string> SrcCols { get; set; }
        public List<string> OutCols { get; set; }
        public abstract void Proceed();
    }
}