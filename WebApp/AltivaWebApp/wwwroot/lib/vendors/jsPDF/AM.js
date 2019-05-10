function generate(modelo) {

  var doc = new jsPDF('p', 'pt');

    var res = doc.autoTableHtmlToJson(document.getElementById("tblAjusteInventario"));
    doc.autoTable(res.columns, res.data, {margin: {top: 80}});

  var header = function(data) {
    doc.setFontSize(18);
    doc.setTextColor(40);
    doc.setFontStyle('normal');
    //doc.addImage(headerImgData, 'JPEG', data.settings.margin.left, 20, 50, 50);
    doc.text("Testing Report", data.settings.margin.center, 50);
  };

  var options = {
    beforePageContent: header,
    margin: {
      top: 80
    },
    startY: doc.autoTableEndPosY() + 20
  };

  doc.autoTable(res.columns, res.data, options);

  doc.save(modelo.nombreDoc);
}



function generate_cutomPDF(modelo) {


    console.log(modelo);
    var comapnyJSON = {
        nombre: modelo.empresa.nombre,
        telefono: modelo.empresa.telefono,
        correo: modelo.empresa.correo,
        cedJuridica: modelo.empresa.cedJuridica
    };

    


    var invoiceJSON = {
        entrada: modelo.entrada,
        salida: modelo.salida,
        saldo: modelo.saldo
    }

    

    var company_logo = {
        src: modelo.empresa.logo,
        w: 80,
        h: 50
    };

    

    var fontSizes = {
        HeadTitleFontSize: 18,
        Head2TitleFontSize: 16,
        TitleFontSize: 14,
        SubTitleFontSize: 12,
        NormalFontSize: 10,
        SmallFontSize: 8
    };

    var lineSpacing = {
        NormalSpacing: 12,
    };
  
    var doc = new jsPDF('p', 'pt');
  
    var rightStartCol1=400;
    var rightStartCol2=480;


    var InitialstartX=40;
    var startX=40;
    var InitialstartY=50;
    var startY=0;

    var lineHeights=12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblAjusteInventario"));
      //res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));

    
    doc.setFontSize(fontSizes.SubTitleFontSize);
    doc.setFont('times');
    doc.setFontType('bold');

    
    
    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
   // doc.addImage(company_logo.src, 'PNG', startX,startY+=50, company_logo.w,company_logo.h);

    doc.textAlign(comapnyJSON.nombre, { align: "left" }, startX, startY += 15 + company_logo.h);
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.textAlign(modelo.empresa.telTitulo, {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
    doc.textAlign(comapnyJSON.telefono, { align: "left" }, 85, startY);

    
    
    doc.setFontType('bold');
    doc.textAlign(modelo.empresa.correoTitulo, { align: "left" }, startX, startY+=lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(comapnyJSON.correo, {align: "left"}, 85, startY);

    doc.setFontType('bold');
    doc.textAlign(modelo.empresa.cedTitulo, { align: "left" }, startX, startY+=lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(comapnyJSON.cedJuridica, {align: "left"}, 112, startY);

    

   var tempY=InitialstartY;

    

    //doc.setFontType('bold');
    //doc.textAlign("INVOICE NO: ", { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(invoiceJSON.entrada, { align: "left" }, rightStartCol2, tempY);

    //doc.setFontType('bold');
    //doc.textAlign("INVOICE Date: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(invoiceJSON.salida, { align: "left" }, rightStartCol2, tempY);

    //doc.setFontType('bold');
    //doc.textAlign("Reference No: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(invoiceJSON.saldo, { align: "left" }, rightStartCol2, tempY);

    
   
    doc.setFontType('normal');
   
    doc.setLineWidth(1);
   // doc.line(20, startY+lineSpacing.NormalSpacing, 580, startY+=lineSpacing.NormalSpacing);
    doc.line(20, startY+lineSpacing.NormalSpacing, 220, startY+lineSpacing.NormalSpacing);
    doc.line(380, startY+lineSpacing.NormalSpacing, 580, startY+lineSpacing.NormalSpacing);
   
    doc.setFontSize(fontSizes.Head2TitleFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
     
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');

   
    


    var header = function(data) {
      doc.setFontSize(8);
      doc.setTextColor(40);
      doc.setFontStyle('normal');
     // doc.textAlign("TAX INVOICE", {align: "center"}, data.settings.margin.left, 50);
 
      //doc.addImage(headerImgData, 'JPEG', data.settings.margin.left, 20, 50, 50);
     // doc.text("Testing Report", 110, 50);
    };
   // doc.autoTable(res.columns, res.data, {margin: {top:  startY+=30}});
   doc.setFontSize(8);
   doc.setFontStyle('normal');
   
    var options = {
      beforePageContent: header,
      margin: {
        top: 50 
      },
      styles: {
        overflow: 'linebreak',
        fontSize: 8,
        rowHeight: 'auto',
        columnWidth: 'wrap'
      },
      columnStyles: {
            1: {columnWidth: 'auto'},
            2: {columnWidth: 'auto'},
            3: {columnWidth: 'auto'},
            4: {columnWidth: 'auto'},
            5: {columnWidth: 'auto'},
            6: { columnWidth: 'auto' },
            7: { columnWidth: 'auto' }
      },
      startY: startY+=50
    };
  
    var columns = [
        { title: modelo.columnas.item, dataKey: "item", width: 90 },
        { title: modelo.columnas.movimiento, dataKey: "movimiento", width: 40 }, 
        { title: modelo.columnas.cantidad, dataKey: "cantidad",width: 40}, 
        { title: modelo.columnas.costo, dataKey: "costo",width: 40}, 
        { title: modelo.columnas.total, dataKey: "total",width: 40}, 
        { title: modelo.columnas.cuentaContable, dataKey: "cuentaContable",width: 40}, 
        { title: modelo.columnas.cuentaCosto, dataKey: "cuentaCosto",width: 40}
    ];

  //var rows = [
  //  {"item": 4, "movimiento": "Shaw", "cantidad": "10","costo" : "12","total":"10","cuentaContable":"120","cuentaCosto":20},

  //];

    var rows = modelo.filas;

  // columnStyles: {
  //   id: {fillColor: 255}
  // },
  
  doc.autoTable(columns, rows, options);   //From dynamic data.
  // doc.autoTable(res.columns, res.data, options); //From htmlTable
  


  //-------Invoice Footer---------------------
  var rightcol1=300;
  var rightcol2=350;

    startY=doc.autoTableEndPosY()+30;
    doc.setFontSize(fontSizes.NormalFontSize);
  
    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.entrada, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.entrada.toString(), { align: "left" }, rightcol2, startY);
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.salida, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.salida.toString(), { align: "left" }, rightcol2, startY);
  

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.saldo, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
    doc.textAlign(invoiceJSON.saldo.toString(), { align: "left" }, rightcol2, startY);
  

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.autorizado, { align: "left" }, 40, startY += lineSpacing.NormalSpacing + 50);

    

    doc.save(modelo.nombreDescarga);
}

//function generate_cutomPDF_landscape() {
  
//    var doc = new jsPDF('landscape', 'pt','a4');
  
//    //var rightStartCol1=400;
//    //var rightStartCol2=480;
//    var rightStartCol1=doc.internal.pageSize.width-195;
//    var rightStartCol2=doc.internal.pageSize.width-115;

//    var InitialstartX=40;
//    var startX=40;
//    var InitialstartY=50;
//    var startY=0;

//    var lineHeights=12;

//    var res = doc.autoTableHtmlToJson(document.getElementById("basic-table"));
//      res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));
    
//    doc.setFontSize(fontSizes.SubTitleFontSize);
//    doc.setFont('times');
//    doc.setFontType('bold');
    
//    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
//    doc.addImage(company_logo.src, 'PNG', startX,startY+=50, company_logo.w,company_logo.h);

//    doc.textAlign(comapnyJSON.CompanyName, {align: "left"}, startX, startY+=15+company_logo.h);
//    doc.setFontSize(fontSizes.NormalFontSize);
//    doc.textAlign("GSTIN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//   // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//    doc.textAlign(comapnyJSON.CompanyGSTIN, {align: "left"}, 80, startY);
    
//    doc.setFontType('bold');
//    doc.textAlign("STATE", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(comapnyJSON.CompanyState, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("PAN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(comapnyJSON.CompanyPAN, {align: "left"}, 80, startY);

//    // doc.setFontType('bold');
//    // doc.textAlign("Address", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    // doc.setFontType('normal');
//    // doc.textAlign(comapnyJSON.CompanyAddressLine1, {align: "left"}, 80, startY);
//    // doc.textAlign(comapnyJSON.CompanyAddressLine2, {align: "left"}, 80, startY+=lineSpacing.NormalSpacing);
//    // doc.textAlign(comapnyJSON.CompanyAddressLine3, {align: "left"}, 80, startY+=lineSpacing.NormalSpacing);
     
//    doc.setFontType('bold');
//    doc.textAlign("PIN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(comapnyJSON.PIN, {align: "left"}, 80, startY);
    
//    doc.setFontType('bold');
//    doc.textAlign("EMAIL", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(comapnyJSON.companyEmail, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("Phone: ", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(comapnyJSON.companyPhno, {align: "left"}, 80, startY);

//   var tempY=InitialstartY;


//    doc.setFontType('bold');
//    doc.textAlign("INVOICE NO: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(invoiceJSON.InvoiceNo, {align: "left"}, rightStartCol2, tempY);


//    doc.setFontType('bold');
//    doc.textAlign("INVOICE Date: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(invoiceJSON.InvoiceDate, {align: "left"}, rightStartCol2, tempY);

//    doc.setFontType('bold');
//    doc.textAlign("Reference No: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(invoiceJSON.RefNo, {align: "left"}, rightStartCol2, tempY);

//    doc.setFontType('bold');
//    doc.textAlign("Total: ", {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(invoiceJSON.TotalAmnt, {align: "left"}, rightStartCol2, tempY);
//    // doc.writeText(0, tempY+=lineSpacing.NormalSpacing ,"INVOICE No  :  "+invoiceJSON.InvoiceNo + '     ', { align: 'right' });
//    // doc.writeText(0, tempY+=lineSpacing.NormalSpacing ,"INVOICE Date: "+invoiceJSON.InvoiceDate + '     ', { align: 'right' });
//    // doc.writeText(0, tempY+=lineSpacing.NormalSpacing ,"Reference No: "+invoiceJSON.RefNo + '     ', { align: 'right' });
//    // doc.writeText(0, tempY+=lineSpacing.NormalSpacing ,"Total       :  Rs. "+invoiceJSON.TotalAmnt + '     ', { align: 'right' });
   
//    doc.setFontType('normal');
   
//    doc.setLineWidth(1);
//    var lineEnd1=(doc.internal.pageSize.width/2)-70;
//    var lineEnd2=doc.internal.pageSize.width-10;
//   // doc.line(20, startY+lineSpacing.NormalSpacing, 580, startY+=lineSpacing.NormalSpacing);
//    doc.line(20, startY+lineSpacing.NormalSpacing, lineEnd1, startY+lineSpacing.NormalSpacing);
//    doc.line(lineEnd1+140, startY+lineSpacing.NormalSpacing, lineEnd2, startY+lineSpacing.NormalSpacing);
   
//    doc.setFontSize(fontSizes.Head2TitleFontSize);
//    doc.setFontType('bold');
//    doc.textAlign("TAX INVOICE", {align: "center"}, startX, startY+=lineSpacing.NormalSpacing+2);
     
//    doc.setFontSize(fontSizes.NormalFontSize);
//    doc.setFontType('bold');

//    //-------Customer Info Billing---------------------
//   var startBilling=startY;

//    doc.textAlign("Billing Address,", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.textAlign(customer_BillingInfoJSON.CustomerName, {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontSize(fontSizes.NormalFontSize);
//    doc.textAlign("GSTIN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//   // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//    doc.textAlign(customer_BillingInfoJSON.CustomerGSTIN, {align: "left"}, 80, startY);
    
   
//    // doc.setFontType('bold');
//    // doc.textAlign("PAN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    // doc.setFontType('normal');
//    // doc.textAlign(customer_BillingInfoJSON.CustomerPAN, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("Address", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine1, {align: "left"}, 80, startY);
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine2, {align: "left"}, 80, startY+=lineSpacing.NormalSpacing);
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine3, {align: "left"}, 80, startY+=lineSpacing.NormalSpacing);
     
//    doc.setFontType('bold');
//    doc.textAlign("STATE", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerState, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("PIN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.PIN, {align: "left"}, 80, startY);
    
//    doc.setFontType('bold');
//    doc.textAlign("EMAIL", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerEmail, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("Phone: ", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerPhno, {align: "left"}, 80, startY);

    

//    //-------Customer Info Shipping---------------------
//   // var rightcol1=340;
//   // var rightcol2=400;
//    var rightcol1=doc.internal.pageSize.width-255;
//    var rightcol2=doc.internal.pageSize.width-195;

//    startY=startBilling;
//    doc.setFontType('bold');
//    doc.textAlign("Shipping Address,", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.textAlign(customer_BillingInfoJSON.CustomerName, {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontSize(fontSizes.NormalFontSize);
//    doc.setFontType('bold');
//    doc.textAlign("GSTIN", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//   // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//    doc.textAlign(customer_BillingInfoJSON.CustomerGSTIN, {align: "left"},rightcol2, startY);
    
   
//    // doc.setFontType('bold');
//    // doc.textAlign("PAN", {align: "left"}, startX, startY+=lineSpacing.NormalSpacing);
//    // doc.setFontType('normal');
//    // doc.textAlign(customer_BillingInfoJSON.CustomerPAN, {align: "left"}, 80, startY);

//    doc.setFontType('bold');
//    doc.textAlign("Address", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine1, {align: "left"}, rightcol2, startY);
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine2, {align: "left"}, rightcol2, startY+=lineSpacing.NormalSpacing);
//    doc.textAlign(customer_BillingInfoJSON.CustomerAddressLine3, {align: "left"}, rightcol2, startY+=lineSpacing.NormalSpacing);
     
//    doc.setFontType('bold');
//    doc.textAlign("STATE", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerState, {align: "left"}, rightcol2, startY);

//    doc.setFontType('bold');
//    doc.textAlign("PIN", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.PIN, {align: "left"}, rightcol2, startY);
    
//    doc.setFontType('bold');
//    doc.textAlign("EMAIL", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerEmail, {align: "left"}, rightcol2, startY);

//    doc.setFontType('bold');
//    doc.textAlign("Phone: ", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//    doc.setFontType('normal');
//    doc.textAlign(customer_BillingInfoJSON.CustomerPhno, {align: "left"}, rightcol2, startY);

    


//    var header = function(data) {
//      doc.setFontSize(8);
//      doc.setTextColor(40);
//      doc.setFontStyle('normal');
//     // doc.textAlign("TAX INVOICE", {align: "center"}, data.settings.margin.left, 50);
 
//      //doc.addImage(headerImgData, 'JPEG', data.settings.margin.left, 20, 50, 50);
//     // doc.text("Testing Report", 110, 50);
//    };
//   // doc.autoTable(res.columns, res.data, {margin: {top:  startY+=30}});
//   doc.setFontSize(8);
//   doc.setFontStyle('normal');
   
//    var options = {
//      beforePageContent: header,
//      margin: {
//        top: 50 
//      },
//      styles: {
//        overflow: 'linebreak',
//        fontSize: 8,
//        rowHeight: 'auto',
//        columnWidth: 'wrap'
//      },
//      columnStyles: {
//        1: {columnWidth: 'auto'},
//        2: {columnWidth: 'auto'},
//        3: {columnWidth: 'auto'},
//        4: {columnWidth: 'auto'},
//        5: {columnWidth: 'auto'},
//        6: {columnWidth: 'auto'},
//      },
//      startY: startY+=50
//    };
  
//    var columns = [
//      {title: "ID", dataKey: "id",width: 90},
//      {title: "Product", dataKey: "Product",width: 40}, 
//      {title: "Rate/Item", dataKey: "Rate/Item",width: 40}, 
//      {title: "Qty", dataKey: "Qty",width: 40}, 
//      {title: "Dsnt", dataKey: "Dsnt",width: 40}, 
//      {title: "S.Total", dataKey: "STotal",width: 40}, 
//      {title: "CGST", dataKey: "CGST",width: 40}, 
//      {title: "SGST", dataKey: "SGST",width: 40}, 
//      {title: "IGST", dataKey: "IGST",width: 40}, 
//      {title: "CESS", dataKey: "CESS",width: 40}, 
//      {title: "Total", dataKey: "Total"}, 
//  ];
//  var rows = [
//    {"id": 1, "Product": "SAMSUNG GALAXY S8 PLUS 64GB HSNCODE: 330854040", "Rate/Item": "10","Qty" : "12","Dsnt":"0","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 2, "Product": "SAMSUNG GALAXY S8 PLUS 64GB HSNCODE: 330854040", "Rate/Item": "10","Qty" : "12","Dsnt":"0","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 3, "Product": "SAMSUNG GALAXY S8 PLUS 64GB HSNCODE: 330854040", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "SAMSUNG GALAXY S8 PLUS 64GB HSNCODE: 330854040", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "SAMSUNG GALAXY S8 PLUS 64GB HSNCODE: 330854040", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": 4, "Product": "Shaw", "Rate/Item": "10","Qty" : "12","Dsnt":"10","STotal":"120","CGST":20,"SGST":20,"IGST":0,"CESS":20,"Total":180},
//    {"id": '', "Product": "", "Rate/Item": "Total","Qty" : "","Dsnt":"20","STotal":"360","CGST":60,"SGST":60,"IGST":0,"CESS":60,"Total":680},
 
//  ];

//  // columnStyles: {
//  //   id: {fillColor: 255}
//  // },
  
//  doc.autoTable(columns, rows, options);   //From dynamic data.
//  // doc.autoTable(res.columns, res.data, options); //From htmlTable
  


//  //-------Invoice Footer---------------------
  
//  var rightcol1=doc.internal.pageSize.width-255;
//  var rightcol2=doc.internal.pageSize.width-195;

//  startY=doc.autoTableEndPosY()+30;
//  doc.setFontSize(fontSizes.NormalFontSize);
  
//  doc.setFontType('bold');
//  doc.textAlign("Sub Total,", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.textAlign(invoiceJSON.SubTotalAmnt, {align: "left"}, rightcol2, startY);
//  doc.setFontSize(fontSizes.NormalFontSize);
//  doc.setFontType('bold');
//  doc.textAlign("CGST Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalCGST, {align: "left"},rightcol2, startY);
  

//  doc.setFontType('bold');
//  doc.textAlign("SGST Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalSGST, {align: "left"},rightcol2, startY);
  
//  doc.setFontType('bold');
//  doc.textAlign("IGST Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalIGST, {align: "left"},rightcol2, startY);
  

//  doc.setFontType('bold');
//  doc.textAlign("CESS Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalCESS, {align: "left"},rightcol2, startY);
  
//  doc.setFontType('bold');
//  doc.textAlign("Total GST Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalGST, {align: "left"},rightcol2, startY);
  

//  doc.setFontType('bold');
//  doc.textAlign("Grand Total Rs.", {align: "left"}, rightcol1, startY+=lineSpacing.NormalSpacing);
//  doc.setFontType('normal');
// // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
//  doc.textAlign(invoiceJSON.TotalAmnt, {align: "left"},rightcol2, startY);
//  doc.setFontType('bold');
//  doc.textAlign('For '+comapnyJSON.CompanyName+',', {align: "center"},rightcol2, startY+=lineSpacing.NormalSpacing+50);
//  doc.textAlign('Authorised Signatory', {align: "center"},rightcol2, startY+=lineSpacing.NormalSpacing+50);
  
//    doc.save("invoice.pdf");
//}


