using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.ApplicationService.DataTransferObject.Responses.BasicDataResponse
{
    public sealed record BasicDataStepOneResponse
    {
        public long BasicDataId { get; set; }
        public required string Name { get; set; }
        public string? OrderOfService { get; set; }
        public string? Tag { get; set; }
        public required string Description { get; set; }
        public string? EquipmentDescription { get; set; }
        public required string BuildingNumber { get; set; }
        public required string DepartmentName { get; set; }
        public long WorkPermissionId { get; set; }
        public int BuildingId { get; set; }
        public int DepartmentId { get; set; }

    }

}
