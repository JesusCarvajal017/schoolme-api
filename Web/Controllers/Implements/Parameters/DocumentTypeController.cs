using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.DocumentType;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class DocumentTypeController
       : GenericController<
       DocumentType,
       DocumentTypeDto,
       DocumentTypeDto>
    {
        public DocumentTypeController(
            IQueryServices<DocumentType, DocumentTypeDto> q,
            ICommandService<DocumentType, DocumentTypeDto> c)
          : base(q, c) { }
    }

}
