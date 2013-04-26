using Wings.Core.Model;
using Wings.Core.Repository;
using Wings.Core.Service;

namespace Wings.Service
{
    public class MealService : CrudService<Meal>, IMealService
    {
        private readonly IFileManagerService fileManagerService;

        public MealService(IRepo<Meal> repo, IFileManagerService fileManagerService) : base(repo)
        {
            this.fileManagerService = fileManagerService;
        }

        public void SetPicture(int id, string root, string filename, int x,int y, int w, int h)
        {
            fileManagerService.MakeImages(root, filename, x, y, w, h);
            var o = repo.Get(id);
            if (o.Picture == filename) return;
            
            var old = o.Picture;
            o.Picture = filename;
            repo.Save();

            if(!string.IsNullOrWhiteSpace(old)) fileManagerService.DeleteImages(root, old);
        }
    }
}