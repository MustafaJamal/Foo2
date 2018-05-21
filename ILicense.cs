
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''
// 
//  Author: Hira Siddiqui
//  Date Of Creation: August, 2013
//  Comments: 
// 
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using QlmLicenseLib;

namespace Edev.LM
{
    /// <summary>
    /// ILicense is an interface through which license can be created and managed easily.
    /// </summary>
    public interface ILicense
    {
        /// <summary>
        /// Define the Product.
        /// </summary>
        /// <param name="productDef">Definition of product aganist which validation is performed.</param>
        OperationResult DefineProduct(Edev.LM.ProductDefinition productDef);

        /// <summary>
        /// Validate and activate your license according to the type of License specified.
        /// </summary>
        /// <param name="licenseType">Type of license to be created.</param>
        /// <param name="activationKey">Activation Key upon which license will be activated.</param>
        /// <param name="computerID">Any string value upon which you want to validate the license.</param>
        /// <param name="computerName">Any string value used in an Online license validation. It can be null/empty.
        /// It will be visible only on QLM console and have no use. </param>
        /// <returns></returns>
        OperationResult ValidateLicense(LicenseTypes licenseType, string activationKey, string computerID, string computerName);
        
        /// <summary>
        /// Unregister the floating License.
        /// Always call this method when license is a floating license, to make the floating seat avaliable.
        /// </summary>
        /// <returns></returns>
        OperationResult UnRegisterFloatingLicense();

        /// <summary>
        /// Creates the Offline activation key aganist the Online activation key.
        /// </summary>
        /// <param name="productDef">Definition of product aganist which Online Activation Key is generated.</param>
        /// <param name="webServiceUrl">server's url.</param>
        /// <param name="onlineActivationKey">Online Activation Key</param>
        /// <param name="computerID">Computer ID</param>
        /// <param name="computerName">Computer Name</param>
        /// <param name="email">Email Address</param>
        /// <param name="userData">Any user specific data</param>
        /// <returns></returns>
        OperationResult CreateOfflineActivationKey(ProductDefinition productDef, Uri webServiceUrl, string onlineActivationKey, string computerID,
                                               string computerName, string email, string userData);

        /// <summary>
        /// Gets the feature that are enabled in current license.
        /// </summary>
        /// <returns>All the enabled feature are maintain in tag of operationResult in form of key-Value pair [Dictionary<FeatureSet, List<Feature>>]</returns>
        OperationResult GetEnabledFeatures();

        /// <summary>
        /// Gets the value indicating if feature is enabled on current license or not.
        /// </summary>
        /// <param name="featureSet">Feature Set.</param>
        /// <param name="feature">Feature Index</param>
        /// <returns>True if feature is enabled else false.</returns>
        bool IsFeatureEnabled(FeatureSet featureSet, Feature feature);

        /// <summary>
        /// Gives the Backward compatibility for previously activated license. Call this method only once before defining the product definition.
        /// </summary>
        /// <param name="computerID">The ComputerID aganist which license was activated.</param>
        OperationResult BackwardCompatible(string computerID);

        /// <summary>
        /// Validate the license and get its status.
        /// Call this property at the application startup to validate the license.
        /// </summary>
        /// <returns></returns>
        OperationResult SyncData();
        /// <summary>
        /// Gets the license status.
        /// </summary>
        /// <returns></returns>
        OperationResult GetLicenseStatus();
        OperationResult IsUserRegistered(string userName);

        OperationResult OfflineFileSaveLocation(string downloadedfilepath);
        [Obsolete]
        bool IsAlreadyRegistered
        {
            get;
        }
        
        /// <summary>
        /// Gets the type of current activated license.
        /// </summary>
        LicenseTypes LicenseType
        {
            get;
        }

        /// <summary>
        /// Get/ Set the server's default webservice url.
        /// </summary>
        Uri ServerWebServiceUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Get/ Set the server's default webservice url.
        /// </summary>
        Uri FloatingWebServiceUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the status of trial license.
        /// </summary>
        bool IsTrialLicenseExpired
        {
            get;
        }

        /// <summary>
        /// Gets the Number of days left in expiry of an the activated licence.
        /// When license is not an evaluation license/ Floating/ Invalid than it will return -1.
        /// </summary>
        int DaysLeftInExpiry
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is all floating seat reserved.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is all floating seat reserved; otherwise, <c>false</c>.
        /// </value>
        bool IsAllFloatingSeatReserved
        {
            get;
            
        }
    }
}