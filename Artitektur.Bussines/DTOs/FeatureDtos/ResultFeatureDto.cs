using Artitektur.Business.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.DTOs.FeatureDtos
{
    public class ResultFeatureDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string BackgroundImage { get; set; }
    }
}
