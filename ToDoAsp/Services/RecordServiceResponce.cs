namespace ToDoAsp.Services
{
    public class RecordServiceResponce<T>
    {
        public T? Data { get; set; }
        public bool Succeed { get; set; }
        public string Message { get; set; } = String.Empty; 
    }
}
