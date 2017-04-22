/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 22.10.2016
 * Time: 13:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	
 #region delegate ProductEventHandler
    /// <summary>
    /// Обработчик события создания нового товара
    /// </summary>
    /// <param name="Product">экземпляр объекта Товар</param>
    /// 
    public delegate void EventHandler();
    
    public delegate void ProductEventHandler(Product prod);
    
    public delegate void PartnerEventHandler(Partner pa);
    
    public delegate void StorageEventHandler(Storage storage);
    #endregion
	
	/// <summary>
	/// Description of TradeApp.
	/// </summary>
	public class TradeApp
	{
		public event EventHandler ChangingApp;
		
		public event ProductEventHandler CreatingProduct;
		
		public event ProductEventHandler ChangingOneProduct;
		
		public event PartnerEventHandler ChangingOnePartner;
		
		public event StorageEventHandler CreatingStorage;
		
		public event StorageEventHandler ChangingOneStorage;
		
		public event EventHandler ChangingAnyProducts;
		
		public event EventHandler ChangingAnyPartners;
		
		public event EventHandler ChangingAnyStorages;
		
		public TradeApp()
		{
		}
		
		public void EventChangeApp() {
			if (ChangingApp!=null)
			ChangingApp();
		}
		
		public void EventNewProductCreate(Product prod) {
			if ((CreatingProduct!=null)&&(prod!=null)) 
				CreatingProduct(prod);
		}
		
		public void EventAnyProductsUpdate() {
			if (ChangingAnyProducts!=null)
			ChangingAnyProducts();
		}
		
		public void EventOneProductUpdate(Product prod) {
			if ((ChangingOneProduct!=null)&&(prod!=null))
			ChangingOneProduct(prod);
		}
		
		public void EventOnePartnerUpdate(Partner pa) {
			if ((ChangingOnePartner!=null)&&(pa!=null))
			ChangingOnePartner(pa);
		}
		
		public void EventAnyPartnersUpdate() {
			if (ChangingAnyPartners!=null)
			ChangingAnyPartners();
		}
		
		public void EventNewStorageCreate(Storage storage) {
			if ((CreatingStorage!=null)&&(storage!=null)) 
				CreatingStorage(storage);
		}
		
		public void EventAnyStoragesUpdate() {
			if (ChangingAnyStorages!=null)
			ChangingAnyStorages();
		}
		
		public void EventOneStorageUpdate(Storage storage) {
			if ((ChangingOneStorage!=null)&&(storage!=null))
			ChangingOneStorage(storage);
		}
	}
}
