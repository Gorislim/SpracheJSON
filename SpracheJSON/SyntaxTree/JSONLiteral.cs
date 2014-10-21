﻿using System;

namespace SpracheJSON
{
    /// <summary>
    /// Represents a literal value in JSON:
    /// A string, number, boolean, or null value
    /// </summary>
    public class JSONLiteral : JSONValue
    {
        /// <summary>
        /// A string representation of the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The type the value is
        /// </summary>
        public LiteralType Type { get; set; }

        public JSONLiteral(string value, LiteralType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Returns Value cast as the appropriate type.
        /// </summary>
        /// <returns></returns>
        public object Get()
        {
            switch (Type)
            {
                case LiteralType.String:
                    return Value;

                case LiteralType.Number:
                    return Convert.ToDouble(Value);

                case LiteralType.Boolean:
                    return (Value.ToLower() == "true") ? true : false;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns a string representing the object in JSON
        /// </summary>
        /// <returns></returns>
        public override string ToJSON()
        {
            var toReturn = "";

            switch (Type)
            {
                case LiteralType.String:
                    foreach (var s in Value.ToCharArray())
                    {
                        switch (s)
                        {
                            case '/':
                                toReturn += "\\/";
                                break;

                            case '\\':
                                toReturn += "\\\\";
                                break;

                            case '\b':
                                toReturn += "\\b";
                                break;

                            case '\f':
                                toReturn += "\\f";
                                break;

                            case '\n':
                                toReturn += "\\n";
                                break;

                            case '\r':
                                toReturn += "\\r";
                                break;

                            case '\t':
                                toReturn += "\\t";
                                break;

                            case '"':
                                toReturn += "\\\"";
                                break;

                            default:
                                toReturn += s;
                                break;
                        }
                    }

                    toReturn = "\"" + toReturn + "\"";
                    break;

                case LiteralType.Null:
                    toReturn = "null";
                    break;

                default:
                    toReturn = Value;
                    break;
            }

            return toReturn;
        }

        /// <summary>
        /// Returns the Value property
        /// </summary>
        /// <returns>this.Value</returns>
        public override string ToString()
        {
            return Value;
        }
    }

    /// <summary>
    /// A list of the types a JSON literal value can be
    /// </summary>
    public enum LiteralType
    {
        String,
        Number,
        Boolean,
        Null
    }
}
