using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspAndWebpack
{
    public static class ExpressionsExtractor
    {
        public static string Lookup<T, TProp>(this HtmlHelper<T> html, Expression<Func<T, TProp>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                return null;

            return memberExpression.Member.Name;
        }

        public static string GetPropName<T, TProp>(this HtmlHelper<T> html, Expression<Func<T, TProp>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                return null;

            return memberExpression.Member.Name;
        }
        public static MvcHtmlString Try<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression
        )
        {
            var builder = new TagBuilder("textarea");
            builder.AddCssClass("ckeditor");
            builder.MergeAttribute("cols", "80");
            builder.MergeAttribute("name", "editor1");
            builder.MergeAttribute("id", expression.Name); // not sure about the id - verify
            var value = ModelMetadata.FromLambdaExpression(
                expression, htmlHelper.ViewData
            ).Model;
            builder.SetInnerText(value.ToString());
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString AngularBrackets<T, U>(
            this HtmlHelper htmlHelper,
            Expression<Func<T, U>> expr,
            string prefix = ""
        ) where T : class
        {
            var memberName = expr.ToCamelCaseName();
            var openBrackets = "{{";
            var closeBrackets = "}}";
            var valToreturn = MvcHtmlString.Create($"{openBrackets}{prefix}.{memberName}{closeBrackets}");

            return valToreturn;
        }
        public static MvcHtmlString AngularString<T, U>(
            this HtmlHelper htmlHelper,
            Expression<Func<T, U>> expr,
            string prefix = ""
        ) where T : class
        {
            var memberName = expr.ToCamelCaseName();
            var valToreturn = MvcHtmlString.Empty;
            
            if (!string.IsNullOrEmpty(prefix))
            {
                valToreturn = MvcHtmlString.Create($"{prefix}.{memberName}");
            }
            else
            {
                valToreturn = MvcHtmlString.Create(memberName);
            }

            return valToreturn;
        }


        public static MvcHtmlString TryT<T, TProperty>(
            this HtmlHelper<T> htmlHelper,
            Expression<Func<T, TProperty>> expression
        )
        {
            var builder = new TagBuilder("textarea");
            builder.AddCssClass("ckeditor");
            builder.MergeAttribute("cols", "80");
            builder.MergeAttribute("name", "editor1");
            builder.MergeAttribute("id", expression.Name); // not sure about the id - verify
            var value = ModelMetadata.FromLambdaExpression(
                expression, htmlHelper.ViewData
            ).Model;
            builder.SetInnerText(value.ToString());
            return MvcHtmlString.Create(builder.ToString());
        }
    }


}
