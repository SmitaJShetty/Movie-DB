using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using com.Entities;

namespace MovieService.ModelBinder
{
    public class MovieModelBinder:IModelBinder
    {
        public bool BindModel(HttpActionContext ActionContext, ModelBindingContext BindingContext)
        {
            if (BindingContext.ModelType != typeof(Movie))
            {
                return false;
            }

            ValueProviderResult val = BindingContext.ValueProvider.GetValue(BindingContext.ModelName);

            if (val == null)
            {
                return false;
            }

            string key = val.RawValue.ToString();

            if (key == null)
            {
                BindingContext.ModelState.AddModelError(BindingContext.ModelName, "Invalid Model Type"); 
                return false;
            }

            Movie result;

            if (Movie.TryParse(key, out result))
            {
                BindingContext.Model = result;
                return true;
            }

            BindingContext.ModelState.AddModelError(key, new Exception("Cannot convert to Movie"));
            return false;
        }
    }
}