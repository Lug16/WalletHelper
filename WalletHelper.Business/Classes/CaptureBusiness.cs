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
    public class Capture : BaseBusiness, IValidate<Entity.Capture>
    {
        public Capture(Entity.User user) : base(user) { }

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
