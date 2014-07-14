
namespace SafeFolder.Data.Repositories
{
    public class FileRepo
    {
        public int SaveSettings(Core.Entities.File file)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.Files.Add(new File
                {
                    Name = file.Name
                });

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }
        
        public void DeleteSettings(Core.Entities.File file)
        {
        }
    }
}
