﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckoutKata.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OnlineStoreEntities3 : DbContext
    {
        public OnlineStoreEntities3()
            : base("name=OnlineStoreEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int DeleteCartItem(Nullable<System.Guid> cartid, string sku)
        {
            var cartidParameter = cartid.HasValue ?
                new ObjectParameter("cartid", cartid) :
                new ObjectParameter("cartid", typeof(System.Guid));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCartItem", cartidParameter, skuParameter);
        }
    
        public virtual ObjectResult<GetCartByCartId_Result> GetCartByCartId(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCartByCartId_Result>("GetCartByCartId", idParameter);
        }
    
        public virtual ObjectResult<GetCartItemBySku_Result> GetCartItemBySku(Nullable<System.Guid> cartid, string sku)
        {
            var cartidParameter = cartid.HasValue ?
                new ObjectParameter("cartid", cartid) :
                new ObjectParameter("cartid", typeof(System.Guid));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCartItemBySku_Result>("GetCartItemBySku", cartidParameter, skuParameter);
        }
    
        public virtual ObjectResult<GetInventory_Result> GetInventory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInventory_Result>("GetInventory");
        }
    
        public virtual ObjectResult<GetOffers_Result> GetOffers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOffers_Result>("GetOffers");
        }
    
        public virtual int InsertCartItem(Nullable<System.Guid> id, string sku, Nullable<int> quantity, Nullable<decimal> lineitemtotal)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(int));
    
            var lineitemtotalParameter = lineitemtotal.HasValue ?
                new ObjectParameter("lineitemtotal", lineitemtotal) :
                new ObjectParameter("lineitemtotal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertCartItem", idParameter, skuParameter, quantityParameter, lineitemtotalParameter);
        }
    
        public virtual int UpdateCartItem(Nullable<System.Guid> cartid, string sku, Nullable<int> quantity, Nullable<decimal> lineitemtotal)
        {
            var cartidParameter = cartid.HasValue ?
                new ObjectParameter("cartid", cartid) :
                new ObjectParameter("cartid", typeof(System.Guid));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(int));
    
            var lineitemtotalParameter = lineitemtotal.HasValue ?
                new ObjectParameter("lineitemtotal", lineitemtotal) :
                new ObjectParameter("lineitemtotal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCartItem", cartidParameter, skuParameter, quantityParameter, lineitemtotalParameter);
        }
    }
}
