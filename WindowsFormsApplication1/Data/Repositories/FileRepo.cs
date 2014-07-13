namespace SafeFolder.Data.Repositories
{
    public class FileRepo
    {
        public int SaveSettings(File file)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.Files.Add(file);

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public void DeleteSettings(File file)
        {
        }
    }
}
