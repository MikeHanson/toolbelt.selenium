using System;

namespace Toolbelt.Selenium
{
    public class TagMismatchException : Exception
    {
        public TagMismatchException(string elementType, string expectedTag, string actualTag)
            : base(string.Format("{0} expects target element to be <{1}>, but was presented with <{2}>",
                                 elementType,
                                 expectedTag,
                                 actualTag)) {}
    }
}