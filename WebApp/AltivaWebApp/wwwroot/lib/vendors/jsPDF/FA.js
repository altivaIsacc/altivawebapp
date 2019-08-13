///////////////Compra Inventario/////////////////////////

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
    var rightStartCol2 = 438;


    var InitialstartX = 40;
    var startX = 40;
    var InitialstartY = 50;
    var startY = 0;

    var lineHeights = 12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblFactura"));
    //res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));


    doc.setFontSize(fontSizes.SubTitleFontSize);
    doc.setFont('times');
    doc.setFontType('bold');



    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
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
    doc.textAlign(modelo.estado, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);

    doc.setFontType('bold');
    doc.textAlign(modelo.fechaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.fecha, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.clienteTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.cliente, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);

    doc.setFontType('bold');
    doc.textAlign(modelo.monedaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.moneda, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.tipoCambio, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);

    doc.setFontType('bold');
    doc.textAlign(modelo.dolarTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.dolar, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.euroTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.euro, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.tipoDocumentoTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.tipoDocumento, { align: "left" }, rightStartCol2, tempY);


    doc.setLineWidth(1);
    // doc.line(20, startY+lineSpacing.NormalSpacing, 580, startY+=lineSpacing.NormalSpacing);
    doc.line(20, startY + lineSpacing.NormalSpacing, 220, startY + lineSpacing.NormalSpacing);
    doc.line(380, startY + lineSpacing.NormalSpacing, 580, startY + lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.Head2TitleFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);

    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');




    var header = function (data) {
        doc.setFontSize(8);
        doc.setTextColor(40);
        doc.setFontStyle('normal');
    };
    
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
            columnWidth: '100%'
        },
        columnStyles: {
            1: { columnWidth: 'auto' },
            2: { columnWidth: 'auto' },
            3: { columnWidth: 'auto' },
            4: { columnWidth: 'auto', halign: 'right' },
        },
        startY: startY += 50
    };

    var columns = [
        { title: modelo.columnas.descripcion, dataKey: "descripcion", width: 40 },
        { title: modelo.columnas.cantidad, dataKey: "cantidad", width: 40 },
        { title: modelo.columnas.precio, dataKey: "precio", width: 40 },
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
    var rightcol2 = 530;

    startY = doc.autoTableEndPosY() + 30;
    doc.setFontSize(fontSizes.NormalFontSize);

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.subtotal, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.subtotal.toString(), { align: "right" }, rightcol2, startY);
    //doc.setFontSize(fontSizes.NormalFontSize);

    if (modelo.tieneDesc) {
        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.descuento, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.descuento.toString(), { align: "right" }, rightcol2, startY);
    }
    

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.impuesto, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.impuesto.toString(), { align: "right" }, rightcol2, startY);


    if (modelo.tieneEx) {
        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.exoneracion, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.exoneracion.toString(), { align: "right" }, rightcol2, startY);
    }


    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.total, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.total.toString(), { align: "right" }, rightcol2, startY);



    //doc.save(modelo.nombreDescarga);

    return doc;
}


function generate_cutomPDFTicket(modelo) {



    var comapnyJSON = {
        nombre: modelo.empresa.nombre,
        telefono: modelo.empresa.telefono,
        correo: modelo.empresa.correo,
        cedJuridica: modelo.empresa.cedJuridica,
        telSingle: modelo.empresa.telSingle
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
        HeadTitleFontSize: 9,
        Head2TitleFontSize: 9,
        TitleFontSize: 9,
        SubTitleFontSize: 9,
        NormalFontSize: 9,
        SmallFontSize: 9
    };

    var lineSpacing = {
        NormalSpacing: 4,
    };

    var doc = new jsPDF('p', 'mm', [297, 75]);

    var rightStartCol1 = 65;
    var rightStartCol2 = 65;


    var InitialstartX = 4;
    var startX = 4;
    var InitialstartY = 4;
    var startY = 5;

    var lineHeights = 12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblFDTicket"));
    //res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));


    doc.setFontSize(fontSizes.SubTitleFontSize);
    doc.setFont('courier');
    doc.setFontType('bold');

    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
    //doc.addImage(company_logo.src, 'JPEG', startX, startY += 50, company_logo.w, company_logo.h);

    doc.textAlign(comapnyJSON.nombre, { align: "center" }, startX, startY);
    doc.setFontSize(fontSizes.NormalFontSize);

    doc.setFontType('normal');
    doc.textAlign(modelo.empresa.telTT, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(comapnyJSON.telefono + " " + modelo.empresa.cedTT + "" + comapnyJSON.cedJuridica, { align: "left" }, 12, startY);


    var tempY = InitialstartY;



    doc.setLineWidth(0.2);
    doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);
    //doc.line(10, startY + lineSpacing.NormalSpacing, 250, startY + lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.Head2TitleFontSize);
    doc.setFontType('normal');
    doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');

    var header = function (data) {
        doc.setFontSize(8);
        doc.setTextColor(40);
        doc.setFont('courier');
        doc.setFontStyle('normal');
    };

    doc.setFontSize(8);
    doc.setFontStyle('normal');

    var options = {
        beforePageContent: header,
        margin: {
            top: 50,
            left: 3.5,
            right: 3.5,
            bottom: 0
        },
        theme: 'plain',

        styles: {
            overflow: 'linebreak',
            fontSize: 9,
            font: 'courier',
            rowHeight: 'auto',
            //columnWidth: 25,
            cellPadding: 0.5
        },

        columnStyles: {
            'descripcion': { columnWidth: 43 },
            'subtotal': { columnWidth: 25, halign: 'right' },
        },
        
        startY: startY += 10
    };

    var columns = [
        { title: modelo.columnas.descripcion, dataKey: "descripcion", width: 43 },
        { title: modelo.columnas.total, dataKey: "subtotal", width: 25 },
    ];

    
    var rows = crearFilas(modelo.filas);


    doc.autoTable(columns, rows, options);   //From dynamic data.
    // doc.autoTable(res.columns, res.data, options); //From htmlTable


    //-------Invoice Footer---------------------
    var rightcol1 = 4;
    var rightcol2 = 70;

    startY = doc.autoTableEndPosY();

    doc.setLineWidth(0.2);
    doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.NormalFontSize);

    doc.setFontType('normal');
    doc.textAlign(modelo.resumen.subtotal, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.subtotal.toString(), { align: "right" }, rightcol2, startY);
    //doc.setFontSize(fontSizes.NormalFontSize);

    doc.setLineWidth(0.2);
    doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);

    if (modelo.tieneDesc) {
        doc.setFontType('normal');
        doc.textAlign(modelo.resumen.descuento, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.descuento.toString(), { align: "right" }, rightcol2, startY);

        doc.setLineWidth(0.2);
        doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);

    }


    doc.setFontType('normal');
    doc.textAlign(modelo.resumen.impuesto, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.impuesto.toString(), { align: "right" }, rightcol2, startY);

    doc.setLineWidth(0.2);
    doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);

    if (modelo.tieneEx) {
        doc.setFontType('normal');
        doc.textAlign(modelo.resumen.exoneracion, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.exoneracion.toString(), { align: "right" }, rightcol2, startY);

        doc.setLineWidth(0.2);
        doc.line(startX, startY + lineSpacing.NormalSpacing, 71, startY += lineSpacing.NormalSpacing);
    }

    

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.total, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.total.toString(), { align: "right" }, rightcol2, startY);



    //doc.save(modelo.nombreDescarga);

    return doc;
}


function crearFilas(filas) {
    var newFilas = [];
    for (var i = 0; i < filas.length; i++) {
        var dato = JSON.parse(JSON.stringify(filas[i]));
        
        if (parseFloat(dato.cantidad) > 1) {

            dato.total = "";
            dato.subtotal = ""; 

            newFilas.push(dato);
            newFilas.push(modelRow(filas[i]));
            
            
        }
        else
            newFilas.push(dato);
        
    }
    
    return newFilas;
}

function modelRow(model) {
    return {
        descripcion: model.cantidad + " x " + model.precio,
        total: model.total,
        cantidad: model.cantidad,
        precio: model.precio,
        subtotal: model.subtotal
    };
}
