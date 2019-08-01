///ajuste manual////



function generate_cutomPDF(modelo) {


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


    console.log(modelo);
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
    var rightStartCol2 = 480;


    var InitialstartX = 40;
    var startX = 40;
    var InitialstartY = 50;
    var startY = 0;

    var lineHeights = 12;

    var res = doc.autoTableHtmlToJson(document.getElementById("tblTomaD"));
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



    var tempY = InitialstartY +55;


    doc.setFontType('bold');
    doc.setTextColor(255, 0, 0);
    doc.textAlign(modelo.estado, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);

    doc.setTextColor(0, 0, 0);

    doc.setFontType('bold');
    doc.textAlign(modelo.fechaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.fecha, { align: "left" }, rightStartCol2 - 40, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.bodegaTitulo, { align: "left" }, rightStartCol1, tempY += lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.bodega, { align: "left" }, rightStartCol2 - 40, tempY);

    doc.setFontType('bold');
    doc.textAlign(modelo.esInicialTitulo + ': ', {align: "left"},  rightStartCol1, tempY+=lineSpacing.NormalSpacing);
    doc.setFontType('normal');
    doc.textAlign(modelo.esInicial, { align: "left" }, rightStartCol2 + 20, tempY);




    doc.setFontType('normal');

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
            columnWidth: '100%'
        },
        columnStyles: {
            1: { columnWidth: 'auto' },
            2: { columnWidth: 'auto' },
            3: { columnWidth: 'auto' },
            4: { columnWidth: 'auto' },
            5: { columnWidth: 'auto' },
            6: { columnWidth: 'auto' },
            7: { columnWidth: 'auto' },
            8: { columnWidth: 'auto' },
            9: { columnWidth: 'auto' }

        },
        startY: startY += 50
    };

    var columns = [
        { title: modelo.columnas.codigo, dataKey: "codigo", width: 90 },
        { title: modelo.columnas.producto, dataKey: "producto", width: 40 },
        { title: modelo.columnas.familia, dataKey: "familia", width: 40 },
        { title: modelo.columnas.costo, dataKey: "costo", width: 40 },
        { title: modelo.columnas.saldo, dataKey: "saldo", width: 40 },
        { title: modelo.columnas.entradas, dataKey: "entradas", width: 40 },
        { title: modelo.columnas.salidas, dataKey: "salidas", width: 40 },
        { title: modelo.columnas.existencia, dataKey: "existencia", width: 40 },
        { title: modelo.columnas.toma, dataKey: "toma", width: 40 },
    ];


    var rows = modelo.filas;

    doc.autoTable(columns, rows, options);   //From dynamic data.
    



    //-------Invoice Footer---------------------
    var rightcol1 = 385;
    var rightcol2 = 445;

    startY = doc.autoTableEndPosY() + 30;
    doc.setFontSize(fontSizes.NormalFontSize);



    doc.setFontType('bold');
    doc.textAlign(modelo.resumen.autorizado, { align: "left" }, 40, startY += lineSpacing.NormalSpacing + 50);



    doc.save(modelo.nombreDescarga);
}





