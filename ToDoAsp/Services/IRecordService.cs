using System.Net;
using ToDoAsp.Models.Records;

namespace ToDoAsp.Services
{
    public interface IRecordService
    {
        public Task<RecordServiceResponce<List<Record>>> GetRecords();
        public Task<RecordServiceResponce<Record>> UpdateRecord(Record record);
        public Task<RecordServiceResponce<Record>> DeleteRecord(int id);
        public Task<RecordServiceResponce<List<Record>>> AddRecord(Record record);
        public Task<RecordServiceResponce<Record>> GetRecord(int id);
    }
}
