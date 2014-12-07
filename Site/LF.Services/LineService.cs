using LF.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF.Entities;

namespace LF.Services
{
    public class LineService : BaseService
    {
        private readonly BaseRepository<Line> lineRepository;

        public LineService(AllServices parent, BaseRepository<Line> lineRepository)
            : base(parent)
        {
	        this.lineRepository = lineRepository;
        }

        public Line GetById(Int32 lineId)
        {
            var line = lineRepository.SingleOrDefault(
                l => l.ID == lineId
            );

            return line;
        }

        public IList<Line> GetAll()
        {
            var lines = lineRepository.GetAll();

            return lines;
        }
    }
}
