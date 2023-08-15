using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ToDoAsp.Models.Records
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public string? Data { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
