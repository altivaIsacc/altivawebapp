
function generate_cutomPDF(modelo) {

    var comapnyJSON = {
        nombre: modelo.empresa.nombre,
        telefono: modelo.empresa.telefono,
        correo: modelo.empresa.correo,
        cedJuridica: modelo.empresa.cedJuridica
    };

    var invoiceJSON = {
        totalCr: modelo.totalCr,
        totalUSD: modelo.totalUSD,
        totalE: modelo.totalE,
        totalCrArqueo: modelo.totalCrArqueo,
        totalUSDArqueo: modelo.totalUSDArqueo,
        totalEArqueo: modelo.totalEArqueo,
        totalUsuarioCierre: modelo.totalUsuarioCierre,
        totalSistemaCierre: modelo.totalSistemaCierre,
        totalDiferenciaCierre: modelo.totalDiferenciaCierre,
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
    var rightStartCol2 = 460;
    var InitialstartX = 40;
    var startX = 40;
    var tempY = 0;
    var startY = 0;
    var midY = 5;
    var lineHeights = 12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblCajaApertura"));
    var ArqueoBase = doc.autoTableHtmlToJson(document.getElementById("tblCajaArqueoBase"));
    var ArqueoDolar = doc.autoTableHtmlToJson(document.getElementById("tblCajaArqueoDolar"));
    var ArqueoEuro = doc.autoTableHtmlToJson(document.getElementById("tblCajaArqueoEuro"));

    //res = doc.autoTableHtmlToJson(document.getElementById("tblInvoiceItemsList"));
    doc.setFontSize(fontSizes.SubTitleFontSize);
    doc.setFont('times');
    doc.setFontType('bold');

    //pdf.addImage(agency_logo.src, 'PNG', logo_sizes.centered_x, _y, logo_sizes.w, logo_sizes.h);
    //doc.addImage(company_logo.src, 'JPEG', startX, startY += 50, company_logo.w, company_logo.h);

    if (company_logo.src != "data:,") {
        doc.addImage(company_logo.src, 'JPEG', startX, startY += 50, company_logo.w, company_logo.h);
        tempY += 50;
    }

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



    doc.setFontType('bold');
    doc.textAlign(modelo.usuarioTitulo, { align: "left" }, rightStartCol1, tempY += 15 + company_logo.h);
    doc.setFontType('normal');
    doc.textAlign(modelo.usuario, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.estadoTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.estado, { align: "left" }, rightStartCol2, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.fechaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.fecha, { align: "left" }, rightStartCol2, tempY);

    //doc.setFontType('bold');
    // doc.textAlign(modelo.proveedorTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.proveedor, { align: "left" }, rightStartCol2, tempY);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.monedaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.moneda, { align: "left" }, rightStartCol2, tempY);

    doc.setLineWidth(1);
    // doc.line(20, startY+lineSpacing.NormalSpacing, 580, startY+=lineSpacing.NormalSpacing);
    doc.line(20, startY + lineSpacing.NormalSpacing, 220, startY + lineSpacing.NormalSpacing);
    doc.line(380, startY + lineSpacing.NormalSpacing, 580, startY + lineSpacing.NormalSpacing);

    doc.setFontSize(fontSizes.Head2TitleFontSize);
    doc.setFontType('bold');

    switch (parseInt(modelo.estadoPdf)) {
        case 1:
            doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
            break;
        case 2:
            doc.textAlign(modelo.nombreDocArqueo, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
            break
        case 3:
            doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
            break;
        case 4:
            doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
            break;
        case 5:
            doc.textAlign(modelo.nombreDoc, { align: "center" }, startX, startY += lineSpacing.NormalSpacing + 2);
            break;
        case 6:
            break;
    }


    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');


    //doc.setFontType('bold');
    //doc.textAlign(modelo.tipoCambio, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.dolarTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.dolar, { align: "left" }, 85, startY);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.euroTitulo, { align: "left" }, startX, startY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.euro, { align: "left" }, 85, startY);

    //var _midY = midY;

    //doc.setFontType('bold');
    //doc.textAlign(modelo.clienteTitulo, { align: "left" }, 150, 129);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.cliente, { align: "left" }, 150, 139);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.usuarioTitulo, { align: "left" }, rightStartCol1 - 10, 129);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.usuario, { align: "left" }, rightStartCol1 - 10, 139);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.vendedorTitulo, { align: "left" }, rightStartCol2, 129);
    //doc.setFontType('normal');
    //doc.textAlign(modelo.vendedor, { align: "left" }, rightStartCol2, 139);


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
            top: 20
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

        },
        startY: startY += 50
    };

    var columns = [
        { title: modelo.columnas.denominacion, dataKey: "denominacion", width: 90 },
        { title: modelo.columnas.cantidad, dataKey: "cantidad", width: 40 },
        { title: modelo.columnas.monto, dataKey: "monto", width: 40 },

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
    var rightcol2 = 520;

    startY = doc.autoTableEndPosY()+ 30;
    doc.setFontSize(fontSizes.NormalFontSize);

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.totalBase, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.totalCr.toString(), { align: "right" }, rightcol2, startY);
    doc.setFontSize(fontSizes.NormalFontSize);
    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.totalDolar, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.totalUSD.toString(), { align: "right" }, rightcol2, startY);

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.totalEuro, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(invoiceJSON.totalE.toString(), { align: "right" }, rightcol2, startY);

    //doc.setFontType('bold');
    //doc.textAlign(modelo.resumen.total, { align: "left" }, rightcol1, startY += lineSpacing.NormalSpacing);
    //doc.setFontType('normal');
    //doc.textAlign(invoiceJSON.total.toString(), { align: "rigth" }, rightcol2, startY);

    if (parseInt(modelo.estadoPdf) === 2) {
        var optionsArqueoBase = {
            beforePageContent: header,
            margin: {
                top: 50
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += 55
        };


        var columnsArqueoBase = [
            { title: modelo.columnasArqueoBase.moneda, dataKey: "moneda", width: 90 },
            { title: modelo.columnasArqueoBase.monto, dataKey: "monto", width: 40 },

        ];

        var rowsArqueoBase = modelo.filaArqueoBase;

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalBaseArqueo, { align: "left" }, 45, startY += lineSpacing.NormalSpacing + 90);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalCrArqueo.toString(), { align: "rigth" }, 117, startY);

        doc.autoTable(columnsArqueoBase, rowsArqueoBase, optionsArqueoBase);   //From dynamic data.

        var optionsArqueoDolar = {
            beforePageContent: header,
            margin: {
                top: 50,
                left: 220,
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += -103,
        };


        var columnsArqueoDolar = [
            { title: modelo.columnasArqueoDolar.moneda, dataKey: "monedaDolar", width: 90 },
            { title: modelo.columnasArqueoDolar.monto, dataKey: "montoDolar", width: 40 },

        ];

        var rowsArqueoDolar = modelo.filaArqueoDolar;

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalDolarArqueo, { align: "left" }, 225, startY += lineSpacing.NormalSpacing + 90);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalUSDArqueo.toString(), { align: "rigth" }, 300, startY);

        doc.autoTable(columnsArqueoDolar, rowsArqueoDolar, optionsArqueoDolar);   //From dynamic data.

        var optionsArqueoEuro = {
            beforePageContent: header,
            margin: {
                top: 50,
                left: 400,
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += -103,
        };


        var columnsArqueoEuro = [
            { title: modelo.columnasArqueoEuro.moneda, dataKey: "monedaEuro", width: 90 },
            { title: modelo.columnasArqueoEuro.monto, dataKey: "montoEuro", width: 40 },

        ];

        var rowsArqueoEuro = modelo.filaArqueoEuro;

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalEuroArqueo, { align: "left" }, 405, startY += lineSpacing.NormalSpacing + 90);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalEArqueo.toString(), { align: "rigth" }, 483, startY);

        doc.autoTable(columnsArqueoEuro, rowsArqueoEuro, optionsArqueoEuro);   //From dynamic data.
    }

    if (parseInt(modelo.estadoPdf) === 4) {

        doc.setFontType('bold');
        doc.textAlign(modelo.tituloUsuario, { align: "left" },47, startY += 20);

        var optionsCierreBase = {
            beforePageContent: header,
            margin: {
                top: 50
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += 20,
        };


        var columnsCierreBase = [
            { title: modelo.columnasCierreBase.moneda, dataKey: "moneda", width: 90 },
            { title: modelo.columnasCierreBase.monto, dataKey: "monto", width: 40 },

        ];

        var rowsCierreBase = modelo.filaCierreBase;

        doc.autoTable(columnsCierreBase, rowsCierreBase, optionsCierreBase);   //From dynamic data.

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalUsuarioCierre, { align: "left" }, 45, startY += 310);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalUsuarioCierre.toString(), { align: "rigth" }, 117, startY);



        var optionsCierreDolar = {
            beforePageContent: header,
            margin: {
                top: 50,
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += -215,
        };


        var columnsCierreDolar = [
            { title: modelo.columnasCierreDolar.moneda, dataKey: "monedaDolar", width: 90 },
            { title: modelo.columnasCierreDolar.monto, dataKey: "montoDolar", width: 40 },

        ];

        var rowsCierreDolar = modelo.filaCierreDolar;

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalSistemaCierre, { align: "left" }, 225, startY += 215);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalSistemaCierre.toString(), { align: "rigth" }, 300, startY);

        doc.autoTable(columnsCierreDolar, rowsCierreDolar, optionsCierreDolar);   //From dynamic data.

        var optionsCierreEuro = {
            beforePageContent: header,
            margin: {
                top: 50,
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += -121,
        };


        var columnsCierreEuro = [
            { title: modelo.columnasCierreEuro.moneda, dataKey: "monedaEuro", width: 90 },
            { title: modelo.columnasCierreEuro.monto, dataKey: "montoEuro", width: 40 },

        ];

        var rowsCierreEuro = modelo.filaCierreEuro;

        doc.setFontType('bold');
        doc.textAlign(modelo.resumen.totalDiferenciaCierre, { align: "left" }, 400, startY += 120);
        doc.setFontType('normal');
        doc.textAlign(invoiceJSON.totalDiferenciaCierre.toString(), { align: "rigth" }, 478, startY);

        doc.autoTable(columnsCierreEuro, rowsCierreEuro, optionsCierreEuro);   //From dynamic data.

        doc.setFontType('bold');
        doc.textAlign(modelo.tituloSistema, { align: "left" }, 220, startY += -330);

        var optionsCierreBaseSistema = {
            beforePageContent: header,
            margin: {
                top: 50,
                left:220
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += 20,
        };


        var columnsCierreBaseSistema = [
            { title: modelo.columnasCierreBaseSistema.moneda, dataKey: "moneda", width: 90 },
            { title: modelo.columnasCierreBaseSistema.monto, dataKey: "monto", width: 40 },

        ];

        var rowsCierreBaseSistema = modelo.filaCierreBaseSistema;

        doc.autoTable(columnsCierreBaseSistema, rowsCierreBaseSistema, optionsCierreBaseSistema);   //From dynamic data.

        var optionsCierreDolarSistema = {
            beforePageContent: header,
            margin: {
                top: 50,
                left:220
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += 95,
        };


        var columnsCierreDolarSistema = [
            { title: modelo.columnasCierreDolarSistema.moneda, dataKey: "monedaDolar", width: 90 },
            { title: modelo.columnasCierreDolarSistema.monto, dataKey: "montoDolar", width: 40 },

        ];

        var rowsCierreDolarSistema = modelo.filaCierreDolarSistema;

        doc.autoTable(columnsCierreDolarSistema, rowsCierreDolarSistema, optionsCierreDolarSistema);   //From dynamic data.

        var optionsCierreEuroSistema = {
            beforePageContent: header,
            margin: {
                top: 50,
                left:220
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
                2: { columnWidth: 100 },
            },
            startY: startY += 95,
        };


        var columnsCierreEuroSistema = [
            { title: modelo.columnasCierreEuroSistema.moneda, dataKey: "monedaEuro", width: 90 },
            { title: modelo.columnasCierreEuroSistema.monto, dataKey: "montoEuro", width: 40 },

        ];

        var rowsCierreEuroSistema = modelo.filaCierreEuroSistema;

        doc.autoTable(columnsCierreEuroSistema, rowsCierreEuroSistema, optionsCierreEuroSistema);   //From dynamic data.

        var optionsCierreBaseDiferencia= {
            beforePageContent: header,
            margin: {
                top: 50,
                left: 470
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
            },
            startY: startY += -190,
        };


        var columnsCierreBaseDiferencia = [
            { title: modelo.columnasCierreBaseDiferencia.diferencia, dataKey: "monto", width: 90 },

        ];

        var rowsCierreBaseDiferencia = modelo.filaCierreBaseDiferencia;

        doc.autoTable(columnsCierreBaseDiferencia, rowsCierreBaseDiferencia, optionsCierreBaseDiferencia);   //From dynamic data.

        var optionsCierreDolarDiferencia = {
            beforePageContent: header,
            margin: {
                top: 50,
                left: 470
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
            },
            startY: startY += 95,
        };


        var columnsCierreDolarDiferencia = [
            { title: modelo.columnasCierreDolarDiferencia.diferencia, dataKey: "monto", width: 40 },

        ];

        var rowsCierreDolarDiferencia = modelo.filaCierreDolarDiferencia;

        doc.autoTable(columnsCierreDolarDiferencia, rowsCierreDolarDiferencia, optionsCierreDolarDiferencia);   //From dynamic data.

        var optionsCierreEuroDiferencia = {
            beforePageContent: header,
            margin: {
                top: 50,
                left: 470
            },
            styles: {
                overflow: 'linebreak',
                fontSize: 10,
                rowHeight: 'auto',
                columnWidth: 80,
            },
            columnStyles: {
                1: { columnWidth: 100 },
            },
            startY: startY += 95,
        };


        var columnsCierreEuroDiferencia = [
            { title: modelo.columnasCierreEuroDiferencia.diferencia, dataKey: "monto", width: 40 },

        ];

        var rowsCierreEuroDiferencia = modelo.filaCierreEuroDiferencia;

        doc.autoTable(columnsCierreEuroDiferencia, rowsCierreEuroDiferencia, optionsCierreEuroDiferencia);   //From dynamic data.
    }

    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.autorizado, { align: "left" }, 40, startY += lineSpacing.NormalSpacing + 150);


    switch (parseInt(modelo.estadoPdf)) {
        case 1:
            doc.save(modelo.nombreDescarga);
            break;
        case 2:
            doc.save(modelo.nombreDescargaArqueo);
            break;
        case 3:
            doc.save(modelo.nombreDescarga);
            break;
        case 4:
            doc.save(modelo.nombreDescarga);
            break;
        case 5:
            doc.save(modelo.nombreDescarga);
            break
        case 6:
            doc.save(modelo.nombreDescarga);
            break;
    }
   
}