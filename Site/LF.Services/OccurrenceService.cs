using LF.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF.Entities;

namespace LF.Services
{
    public class OccurrenceService : BaseService
    {
        private readonly BaseRepository<Occurrence> occurrenceRepository;

        public OccurrenceService(AllServices parent, BaseRepository<Occurrence> occurrenceRepository)
            : base(parent)
        {
	        this.occurrenceRepository = occurrenceRepository;
        }

        public Occurrence GetById(Int32 occurrenceId)
        {
            var occurrence = occurrenceRepository.SingleOrDefault(
                p => p.ID == occurrenceId
            );

            return occurrence;
        }

        public IList<Occurrence> GetOccurrencesByStation(Int32 stationId)
        {
            var StationOccurences = occurrenceRepository.NewQuery()
                .FilterSimple(p => p.Station.ID == stationId)
                .OrderBy(p => p.Date, false)
                .Result;

            return StationOccurences;
        }

        public void Save(Occurrence newOccurrence)
        {
            InTransaction(() =>
            {
                occurrenceRepository.SaveOrUpdate(newOccurrence);
            });
        }



    }
}
