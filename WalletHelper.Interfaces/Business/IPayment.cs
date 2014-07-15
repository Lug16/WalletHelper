//using System;
//using System.Collections.Generic;
//using WalletHelper.Entity;
//using WalletHelper.Entity.Enums;

//namespace WalletHelper.Interfaces
//{
//    /// <summary>
//    /// Interfaz para la clase de negocio Payment
//    /// </summary>
//    public interface IPayment
//    {
//        /// <summary>
//        /// Crea un movimiento a partir de una captura de imagen
//        /// </summary>
//        /// <param name="capture">Entidad que contiene la imagen capturada</param>
//        /// <returns><c>IResponseBusiness<Entity.Payment></c></returns>
//        IResponseBusiness<Payment> InsertCapture(Capture capture);
//        /// <summary>
//        /// Obtiene los movimientos del día.
//        /// </summary>
//        /// <param name="configPage">Configuración de la paginación.</param>
//        /// <returns></returns>
//        IEnumerable<Payment> GetPaymentsDay(PagedQueryObject configPage);
//        /// <summary>
//        /// Obtiene los movimientos según un rango de fechas.
//        /// </summary>
//        /// <param name="begin">Fecha inicial.</param>
//        /// <param name="end">Fecha final.</param>
//        /// <param name="configPage">Configuración de la paginación.</param>
//        /// <returns></returns>
//        IEnumerable<Payment> GetPayments(DateTime begin, DateTime end, PagedQueryObject configPage);
//        /// <summary>
//        /// Obtiene los movimientos según el filtro PaymentValues.
//        /// </summary>
//        /// <param name="paymentValues">Filtro aplicar a los movimientos.</param>
//        /// <param name="configPage">Configuración de la paginación.</param>
//        /// <returns></returns>
//        IEnumerable<PaymentValue> GetPaymentValues(PaymentValues paymentValues, PagedQueryObject configPage);
//    }
//}
