using LF.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF.Entities;

namespace LF.Services
{
    public class StationService : BaseService
    {
        private readonly BaseRepository<Station> stationRepository;

        public StationService(AllServices parent, BaseRepository<Station> stationRepository)
            : base(parent)
        {
	        this.stationRepository = stationRepository;
        }

        public Station GetById(Int32 stationId)
        {
            var station = stationRepository.SingleOrDefault(
                p => p.ID == stationId
            );

            return station;
        }

        public IList<Station> GetStationByLine(Int32 stationId)
        {
            var stations = stationRepository.NewQuery()
                .FilterSimple(p => p.Line.ID == stationId)
                .Result;

            return stations;
        }
    }
}
