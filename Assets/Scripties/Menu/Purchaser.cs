using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;


 
    public class Purchaser : MonoBehaviour, IStoreListener
    {
        private static IStoreController m_StoreController;          // The Unity Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

       
        public static string kProduct_5_hints = "fivehints";
        public static string kProduct_10_Hints = "tenhints";
        public static string kProduct_NO_ADS = "noads";

      

        void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }
        public void InitializePurchasing()
        {
            // If we have already connected to Purchasing ...
            if (IsInitialized())
            {
                // ... we are done here.
                return;
            }

           
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(kProduct_5_hints, ProductType.Consumable);
            builder.AddProduct(kProduct_10_Hints, ProductType.Consumable);
            builder.AddProduct(kProduct_NO_ADS, ProductType.NonConsumable);
            UnityPurchasing.Initialize(this, builder);
        }
        private bool IsInitialized()
        {
            
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }



        public void Buy_5_hints()
        {
            
            BuyProductID(kProduct_5_hints);
        }
        public void Buy_10_hints()
    {

        BuyProductID(kProduct_10_Hints);
    }
        public void Buy_NO_ADS()
        {
           
            BuyProductID(kProduct_NO_ADS);
        }



        void BuyProductID(string productId)
        {
          
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productId);

                
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                   
                    m_StoreController.InitiatePurchase(product);
                }
               
                else
                {
                    
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
           
            else
            {
               
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            
            Debug.Log("OnInitialized: PASS");

            m_StoreController = controller;
            m_StoreExtensionProvider = extensions;
        }
        public void OnInitializeFailed(InitializationFailureReason error)
        {
           
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
           
            if (String.Equals(args.purchasedProduct.definition.id, kProduct_5_hints, StringComparison.Ordinal))
            {
                Debug.Log("You have +5 hints!");
            PlayerPrefs.SetInt("hint", PlayerPrefs.GetInt("hint") + 5);
                      
            }
           
            else if (String.Equals(args.purchasedProduct.definition.id, kProduct_10_Hints, StringComparison.Ordinal))
            {
            Debug.Log("You have +10 hints!");
            PlayerPrefs.SetInt("hint", PlayerPrefs.GetInt("hint") + 10);
        }

            else if (String.Equals(args.purchasedProduct.definition.id, kProduct_NO_ADS, StringComparison.Ordinal))
            {
            Debug.Log("No ADS!");
            PlayerPrefs.SetString("noAds", "yes");
             }

        else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }         
            return PurchaseProcessingResult.Complete;
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
           
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }
