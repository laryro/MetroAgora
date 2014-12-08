using LF.Authentication;
using LF.Entities;
using LF.DBManager;

namespace LF.Services
{
    public class AllServices
    {
        private AllServices()
        {
            var user = new BaseRepository<User>();
            var login = new BaseRepository<Login>();
            var occurence = new BaseRepository<Occurrence>();
            var station = new BaseRepository<Station>();
            var line = new BaseRepository<Line>();
            var category = new BaseRepository<Category>();

            User = new UserService(this, user, login);
            Occurrence = new OccurrenceService(this, occurence);
            Station = new StationService(this, station);
            Line = new LineService(this, line);
            Category = new CategoryService(this, category);

            Current = new Current(User);
        }

        private static AllServices access;

        public static AllServices Access
        {
            get
            {
                return access
                    ?? (access = new AllServices());
            }
        }

        public Current Current { get; private set; }

        public UserService User { get; private set; }

        public OccurrenceService Occurrence { get; private set; }
        
        public StationService Station { get; private set; }

        public LineService Line { get; private set; }
        
        public CategoryService Category { get; private set; }

    }
}
