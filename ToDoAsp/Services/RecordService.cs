using Microsoft.EntityFrameworkCore;
using ToDoAsp.Data;
using ToDoAsp.Models.Records;

namespace ToDoAsp.Services
{
    
    public class RecordService : IRecordService
    {
        private ApplicationDbContext dbContext;
        public RecordService(ApplicationDbContext dbContext)
        {
           this.dbContext = dbContext;
        }

        public async Task<RecordServiceResponce<List<Record>>> AddRecord(Record record)
        {
           var responce = new RecordServiceResponce<List<Record>>();
           try
           {
               dbContext.Add(record);
               responce.Data = await dbContext.Records.ToListAsync();
           }
           catch (Exception ex)
           {
               responce.Data = null;
               responce.Succeed = false;
               responce.Message = ex.Message;
               return responce;
           }

           await dbContext.SaveChangesAsync();
           responce.Succeed = true;
           return responce;           
        }

        public async Task<RecordServiceResponce<Record>> DeleteRecord(int id)
        {
           var responce = new RecordServiceResponce<Record>();
           try
           {
               dbContext.Remove(dbContext.Records.First(record => record.Id == id));
               responce.Data = null;
           }
           catch (Exception ex)
           {
               responce.Data = null;
               responce.Succeed = false;
               responce.Message = ex.Message;
               return responce;
           }

           await dbContext.SaveChangesAsync();
           responce.Succeed = true;
           return responce;
        }

         public async Task<RecordServiceResponce<List<Record>>> GetRecords()
         {
            var responce = new RecordServiceResponce<List<Record>>();
            try
            {
                responce.Data = await dbContext.Records.ToListAsync();
            }
            catch (Exception ex)
            {
                responce.Data = null;
                responce.Succeed = false;
                responce.Message = ex.Message;
                return responce;
            }

            responce.Succeed = true;
            return responce;
         }

        public async Task<RecordServiceResponce<Record>> GetRecord(int id)
        {
            var responce = new RecordServiceResponce<Record>();
            try
            {
                responce.Data = dbContext.Records.First(record => record.Id == id);
            }
            catch(Exception ex)
            {
                responce.Succeed=false;
                responce.Message = ex.Message;
            }

            responce.Succeed = true;
            return responce;
        }

        public async Task<RecordServiceResponce<Record>> UpdateRecord(Record record)
        {
           var responce = new RecordServiceResponce<Record>();
           try
           {
               dbContext.Update(record);
               responce.Data = record;
           }
           catch (Exception ex)
           {
               responce.Data = null;
               responce.Succeed = false;
               responce.Message = ex.Message;
               return responce;
           }

           await dbContext.SaveChangesAsync();            
           responce.Succeed = true;
           return responce;

        }
    }
}
