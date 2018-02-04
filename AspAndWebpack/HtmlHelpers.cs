using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspAndWebpack
{

        public static class AngularHelperExtension
        {
            //Allows us to say Html.Angular in our view
            public static AngularHelper<TModel> Angular<TModel>(this HtmlHelper<TModel> helper)
            {
                return new AngularHelper<TModel>(helper);
            }

            
        }

        public class AngularHelper<TModel>
        {
            private readonly HtmlHelper<TModel> _htmlHelper;

            public AngularHelper(HtmlHelper<TModel> helper)
            {
                _htmlHelper = helper;
            }

            public AngularModelHelper<TModel> ModelFor(string expressionPrefix)
            {
                return new AngularModelHelper<TModel>(_htmlHelper, expressionPrefix);
            }

            //public HtmlTag FormForModel(string expressionToPrefix)
            //{
            //    var modelHelper = ModelFor(expressionToPrefix);
            //    var formGroupForMethodGeneric = typeof(AngularModelHelper<TModel>)
            //        .GetMethod("FormGroupFor");
            //    var wrapperTag = new HtmlTag("div").NoTag();
            //    foreach (var prop in typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            //    {
            //        //Skip hidden property attributes
            //        if (prop.GetCustomAttributes().OfType<HiddenInputAttribute>().Any()) continue;

            //        var formGroupForProp = formGroupForMethodGeneric.MakeGenericMethod(prop.PropertyType);
            //        var propertyLambda = MakeLambda(prop);
            //        var formGroupTag = (HtmlTag)formGroupForProp.Invoke(modelHelper, new[] { propertyLambda });
            //        wrapperTag.Append(formGroupTag);
            //    }
            //    return wrapperTag;
            //}

            //Constructs a lambda in the formof x=> x.PropName
            private object MakeLambda(PropertyInfo prop)
            {
                var parameter = Expression.Parameter(typeof(TModel), "x");
                var property = Expression.Property(parameter, prop);
                var funcType = typeof(Func<,>).MakeGenericType(typeof(TModel), prop.PropertyType);
                return Expression.Lambda(funcType, property, parameter);
            }

            //public UIRatingTag UIRating(string model)
            //{
            //    return new UIRatingTag(model);
            //}

            //Generic method that takes in an expression
            //Identifies which asp.net mvc controller action is going to provide data for the grid
            //public GridTag GridFor<TController>(Expression<Action<TController>> targetAction) where TController : Controller
            //{
            //    //Need to translate target action into an actual URL
            //    var dataUrl = _htmlHelper.BuildUrlFromExpression(targetAction);

            //    return new GridTag(dataUrl);
            //}
        }
}
