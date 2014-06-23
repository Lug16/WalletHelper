using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletHelper.Common;
using WalletHelper.Entity.Enums;
using WalletHelper.Interfaces;

namespace WalletHelper.Business
{
    public class Capture:IValidate<Entity.Capture>
    {
        private ResourceReacher _resourceReacher = new ResourceReacher(ResourceTypes.Messages);

        public IResponseValidate Validate(Entity.Capture entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            IResponseValidate validate = new ResponseValidate();
            validate.Message = string.Empty;

            if (entity.Image == null)
                validate.Message += _resourceReacher.GetString("CaptureImageNull");
            if (entity.Payment==null)
                validate.Message += _resourceReacher.GetString("CapturePaymentNull");

            validate.IsValid = string.IsNullOrEmpty(validate.Message);

            return validate;
        }
    }
}
