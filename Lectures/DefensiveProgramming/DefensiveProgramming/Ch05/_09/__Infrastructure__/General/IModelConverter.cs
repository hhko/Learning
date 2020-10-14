using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Ch03._09.__Infrastructure__.General
{
    public interface IModelConverter<TModel, TPersistence>
    {
        TModel ToModel(TPersistence persisted);
        TPersistence ToPersisted(TModel model);
        void CopyChanges(TModel from, TPersistence to);
    }
}
