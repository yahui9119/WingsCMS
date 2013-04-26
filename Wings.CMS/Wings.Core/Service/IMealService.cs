using  Wings.Core.Model;
using  Wings.Core.Service;

namespace  Wings.Core.Service
{
    public interface IMealService : ICrudService<Meal>
    {
        void SetPicture(int id, string root, string filename, int x, int y, int w, int h);
    }
}