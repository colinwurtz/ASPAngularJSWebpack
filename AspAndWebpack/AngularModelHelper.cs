using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspAndWebpack
{
    public class AngularModelHelper<TModel>
    {
        protected readonly HtmlHelper Helper;
        private readonly string _expressionPrefix;

        public AngularModelHelper(HtmlHelper helper, string expressionPrefix)
        {
            Helper = helper;
            _expressionPrefix = expressionPrefix;
        }

        /// <summary>
        /// Converts an lambda expression into a camel-cased string, prefixed
        /// with the helper's configured prefix expression, ie:
        /// vm.model.parentProperty.childProperty
        /// </summary>
        public IHtmlString ExpressionFor<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var expressionText = ExpressionForInternal(property);
            return new MvcHtmlString(expressionText);
        }

        /// <summary>
        /// Converts a lambda expression into a camel-cased AngularJS binding expression, ie:
        /// {{vm.model.parentProperty.childProperty}} 
        /// </summary>
        public IHtmlString BindingFor<TProp>(Expression<Func<TModel, TProp>> property)
        {
            return MvcHtmlString.Create("{{" + ExpressionForInternal(property) + "}}");
        }

        

        private string ExpressionForInternal<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var camelCaseName = property.ToCamelCaseName();

            var expression = !string.IsNullOrEmpty(_expressionPrefix)
                ? _expressionPrefix + "." + camelCaseName
                : camelCaseName;

            return expression;
        }

        //public HtmlTag FormGroupFor<TProp>(Expression<Func<TModel, TProp>> property)
        //{
        //    //Get some information about our model, this will expose annotations
        //    var metadata = ModelMetadata.FromLambdaExpression(property, new ViewDataDictionary<TModel>());

        //    //Turns x=>x.SomeName into "SomeName"
        //    var name = ExpressionHelper.GetExpressionText(property);

        //    //Turns x=>x.SomeName into vm.model.someName
        //    var expression = ExpressionForInternal(property);

        //    //Creates <div class="form-group">
        //    var formGroup = new HtmlTag("div")
        //        .AddClasses("form-group")
        //        .Attr("form-group-validation", name);

        //    //If dislay annotation for name is set use it for label, if not humanize the name
        //    //Humanizer will conver "WorkAddress" to "Work Address"
        //    var labelText = metadata.DisplayName ?? name.Humanize(LetterCasing.Title);

        //    //Creates <label class="control-label" for="Name>Name</label>
        //    var label = new HtmlTag("label")
        //        .AddClass("control-label")
        //        .Attr("for", name)
        //        .Text(labelText);

        //    //If metadata is multiline text, set the tag name to textarea
        //    var tagName = metadata.DataTypeName == "MultilineText"
        //        ? "textarea"
        //        : "input";

        //    //Checks if placeholder is specfied, if not just use label text
        //    var placeholder = metadata.Watermark ??
        //        labelText + "...";

        //    //Creates <input ng-model="expression"
        //    //         class="form-control" name="Name" type="text">
        //    var input = new HtmlTag(tagName)
        //        .AddClass("form-control")
        //        .Attr("ng-model", expression)
        //        .Attr("name", name)
        //        .Attr("type", "text")
        //        .Attr("placeholder", placeholder);

        //    ApplyValidationToInput(input, metadata);

        //    return formGroup.Append(label)
        //        .Append(input);

        //}

        //private void ApplyValidationToInput(HtmlTag input, ModelMetadata metadata)
        //{
        //    //only adding a few rules, could add more later if necessary
        //    if (metadata.IsRequired)
        //        input.Attr("required", "");

        //    if (metadata.DataTypeName == "EmailAddress")
        //        input.Attr("type", "email");

        //    if (metadata.DataTypeName == "PhoneNumber")
        //        input.Attr("pattern", @"[\ 0-9()-]+"); //Really crappy regex
        //}
    }
}
