
function generate_cutomPDF(modelo) {



    var comapnyJSON = {
        nombre: modelo.empresa.nombre,
        telefono: modelo.empresa.telefono,
        correo: modelo.empresa.correo,
        cedJuridica: modelo.empresa.cedJuridica
    };




    var invoiceJSON = {
        subtotal: modelo.subtotal,
        descuento: modelo.descuento,
        impuesto: modelo.impuesto,
        total: modelo.total
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

    var rightStartCol1 = 400;
    var rightStartCol2 = 490;


    var InitialstartX = 40;
    var startX = 40;
    var InitialstartY = 50;
    var startY = 0;
    var midY = 5;

    var lineHeights = 12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblDetalleCotizacion"));
    //res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));

    doc.setFontSize(fontSizes.SubTitleFontSize);
    doc.setFont('times');
    doc.setFontType('bold');

    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
    //  doc.addImage(company_logo.src, 'JPEG', startX, startY += 50, company_logo.w, company_logo.h);
    doc.addImage(company_logo.src, 'JPEG', startX, startY += 50, company_logo.w, company_logo.h);

    doc.textAlign(comapnyJSON.nombre, { align: "left" }, startX, startY += 15 + company_logo.h);
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.textAlign(modelo.empresa.telTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    // var w = doc.getStringUnitWidth('GSTIN') * NormalFontSize;
    doc.textAlign(comapnyJSON.telefono, { align: "left" }, 85, startY);


    doc.setFontType('bold');
    doc.textAlign(modelo.empresa.correoTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(comapnyJSON.correo, { align: "left" }, 85, startY);

    doc.setFontType('bold');
    doc.textAlign(modelo.empresa.cedTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(comapnyJSON.cedJuridica, { align: "left" }, 112, startY);



    var tempY = InitialstartY;

    doc.setFontType('bold');
    doc.textAlign(modelo.estadoTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.estado, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.fechaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.fecha, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.fechaVencimientoTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.fechaVencimiento, { align: "left" }, rightStartCol2, tempY);

    //doc.setFontType('bold');
    // doc.textAlign(modelo.proveedorTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.proveedor, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.monedaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.moneda, { align: "left" }, rightStartCol2, tempY);



    doc.setLineWidth(1);
    // doc.line(20, startY+lineSpacing.NormalSpacing, 580, startY+=lineSpacing.NormalSpacing);
    doc.line(20, startY + lineSpacing.NormalSpacing, 220, startY + lineSpacing.NormalSpacing);
    doc.line(380, startY + lineSpacing.NormalSpacing, 580, startY + lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.Head2TitleFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);

    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');


    doc.setFontType('bold');
    doc.textAlign(modelo.tipoCambio, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);

    doc.setFontType('bold');
    doc.textAlign(modelo.dolarTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.dolar, { align: "left" }, 85, startY);

    doc.setFontType('bold');
    doc.textAlign(modelo.euroTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.euro, { align: "left" }, 85, startY);

    var _midY = midY;

    doc.setFontType('bold');
    doc.textAlign(modelo.clienteTitulo, { align: "left" }, 150, 129);
    doc.setFontType('normal');
    doc.textAlign(modelo.cliente, { align: "left" }, 150, 139);

    doc.setFontType('bold');
    doc.textAlign(modelo.usuarioTitulo, { align: "left" }, rightStartCol1 - 10, 129);
    doc.setFontType('normal');
    doc.textAlign(modelo.usuario, { align: "left" }, rightStartCol1 - 10, 139);

    doc.setFontType('bold');
    doc.textAlign(modelo.vendedorTitulo, { align: "left" }, rightStartCol2, 129);
    doc.setFontType('normal');
    doc.textAlign(modelo.vendedor, { align: "left" }, rightStartCol2, 139);


    var header = function (data) {
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
            fontSize: 10,
            rowHeight: 'auto',
            columnWidth: '100%',




        },
        columnStyles: {
            1: { columnWidth: 'auto' },
            2: { columnWidth: 'auto' },
            3: { columnWidth: 'auto' },
            4: { columnWidth: 'auto' },
            5: { columnWidth: 'auto' }
        },
        startY: startY += 50
    };

    var columns = [
        { title: modelo.columnas.item, dataKey: "item", width: 90 },
        { title: modelo.columnas.cantidad, dataKey: "cantidad", width: 40 },
        { title: modelo.columnas.descuento, dataKey: "descuento", width: 40 },
        { title: modelo.columnas.precioUnitario, dataKey: "precioUnitario", width: 40 },
        { title: modelo.columnas.total, dataKey: "total", width: 40 },
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
    var rightcol1 = 400;
    var rightcol2 = 490;

    startY = doc.autoTableEndPosY() + 30;
    doc.setFontSize(fontSizes.NormalFontSize);

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.subtotal, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.subtotal.toString(), { align: "rigth" }, rightcol2, startY);
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.descuento, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.descuento.toString(), { align: "rigth" }, rightcol2, startY);


    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.impuesto, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.impuesto.toString(), { align: "rigth" }, rightcol2, startY);

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.total, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.total.toString(), { align: "rigth" }, rightcol2, startY);


    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.autorizado, { align: "left" }, 40, startY += lineSpacing.NormalSpacing + 50);



    doc.save(modelo.nombreDescarga);
}