using System.Collections.Generic;
using Microsoft.Web.XmlTransform;
using System.Linq;
using System.Xml;
using Utilities.Cryptography;

namespace CustomXdtTransforms.Transforms
{
    /// <summary>
    /// XDT Transform that encodes <c>InnerText</c> for <c>App.config</c> elements and attributes by applying configuration transformers at build time.
    /// </summary>
    public class Encode : Transform
    {
        /// <summary>
        /// Default element's attribute <c>XPath</c> to encode <c>InnerText</c> of.
        /// Added for previous version compatibility.
        /// </summary>
        const string DefaultAttributeName = "@value";

        readonly IEncryptorDecryptor _encryptorDecryptor = new EncryptorDecryptor();

        /// <summary>
        /// Initializes new instance of <c>Encode</c> class.
        /// </summary>
        public Encode()
        {
            //Flag, that allows MSBuild to apply transform for each element it's applied for:
            ApplyTransformToAllTargetNodes = true;
        }

        /// <summary>
        /// Performs encoding transformation for each <c>XmlElement</c> of <c>App.config</c> where <c>Encode</c> transform is applied for.
        /// </summary>
        protected override void Apply()
        {
            //If target node has no attributes - skip the transform:
            if (TargetNode.Attributes == null)
                return;

            //Getting list of passed XPath arguments to this Encode instance:
            var encodeXPathArguments = new List<string>();
            if (Arguments != null)
                encodeXPathArguments.AddRange(Arguments);

            //Adding DefaultAttributeName to XPath arguments if it's not present:
            if (!encodeXPathArguments.Contains(DefaultAttributeName))
                encodeXPathArguments.Add(DefaultAttributeName);

            //Looping thru TargetNodes
            foreach (var targetNode in TargetNodes.OfType<XmlElement>())
            {
                //For each TargetNode looping thru encodeXPathArguments
                foreach (var arg in encodeXPathArguments)
                {
                    //Getting TargetNode.XmlNode by XPath arg:
                    var destinationNode = targetNode.SelectSingleNode(arg);

                    if (destinationNode == null)
                        continue;

                    //TransformNode.XmlNode by XPath arg:
                    var applyTransformNode = TransformNode.SelectSingleNode(arg);

                    //Determine which XmlNode.InnerText to encode:
                    string valueToEncode =
                        applyTransformNode == null || string.IsNullOrEmpty(applyTransformNode.InnerText)
                            ? destinationNode.InnerText //Getting default destination XmlNode.InnerText
                            : applyTransformNode.InnerText; //Getting XmlNode.InnerText specified in App.config transformer

                    if (string.IsNullOrEmpty(valueToEncode))
                        continue;

                    //If valueToEncode is OK - then encrypt it and assign to destination XmlNode.InnerText:
                    destinationNode.InnerText = _encryptorDecryptor.Encrypt(valueToEncode);
                }
            }
        }
    }
}