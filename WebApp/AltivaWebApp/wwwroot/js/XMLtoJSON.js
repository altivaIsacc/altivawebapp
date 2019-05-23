
//function xmlToJson(xml) {

//    // Create the return object
//    var obj = {};

//    // text node
//    if (4 === xml.nodeType) {
//        obj = xml.nodeValue;
//    }

//    if (xml.hasChildNodes()) {
//        for (var i = 0; i < xml.childNodes.length; i++) {
//            var TEXT_NODE_TYPE_NAME = '#text',
//                item = xml.childNodes.item(i),
//                nodeName = item.nodeName,
//                content;

//            if (TEXT_NODE_TYPE_NAME === nodeName) {
//                //single textNode or next sibling has a different name
//                if ((null === xml.nextSibling) || (xml.localName !== xml.nextSibling.localName)) {
//                    content = xml.textContent;

//                    //we have a sibling with the same name
//                } else if (xml.localName === xml.nextSibling.localName) {
//                    //if it is the first node of its parents childNodes, send it back as an array
//                    content = (xml.parentElement.childNodes[0] === xml) ? [xml.textContent] : xml.textContent;
//                }
//                return content;
//            } else {
//                if ('undefined' === typeof (obj[nodeName])) {
//                    obj[nodeName] = xmlToJson(item);
//                } else {
//                    if ('undefined' === typeof (obj[nodeName].length)) {
//                        var old = obj[nodeName];
//                        obj[nodeName] = [];
//                        obj[nodeName].push(old);
//                    }

//                    obj[nodeName].push(xmlToJson(item));
//                }
//            }
//        }
//    }
//    return obj;
//}

//function xmlToJson(xml) {

//    // Create the return object
//    var obj = {};

//    if (xml.nodeType == 1) { // element
//        // do attributes
//        if (xml.attributes.length > 0) {
//            obj["@attributes"] = {};
//            for (var j = 0; j < xml.attributes.length; j++) {
//                var attribute = xml.attributes.item(j);
//                obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
//            }
//        }
//    } else if (xml.nodeType == 3) { // text
//        obj = xml.nodeValue;
//    }

//    // do children
//    // If just one text node inside
//    if (xml.hasChildNodes() && xml.childNodes.length === 1 && xml.childNodes[0].nodeType === 3) {
//        obj = xml.childNodes[0].nodeValue;
//    }
//    else if (xml.hasChildNodes()) {
//        for (var i = 0; i < xml.childNodes.length; i++) {
//            var item = xml.childNodes.item(i);
//            var nodeName = item.nodeName;
//            if (typeof (obj[nodeName]) == "undefined") {
//                obj[nodeName] = xmlToJson(item);
//            } else {
//                if (typeof (obj[nodeName].push) == "undefined") {
//                    var old = obj[nodeName];
//                    obj[nodeName] = [];
//                    obj[nodeName].push(old);
//                }
//                obj[nodeName].push(xmlToJson(item));
//            }
//        }
//    }
//    return obj;
//}
function xmlToJson(xml) {

   

    // Create the return object
    var obj = {};

    if (xml.nodeType == 1) { // element
        // do attributes
        if (xml.attributes.length > 0) {
            obj["@attributes"] = {};
            for (var j = 0; j < xml.attributes.length; j++) {
                var attribute = xml.attributes.item(j);
                obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
            }
        }
    } else if (xml.nodeType == 3) { // text
        obj = xml.nodeValue;
    }

    // do children
    if (xml.hasChildNodes()) {
        for (var i = 0; i < xml.childNodes.length; i++) {
            var item = xml.childNodes.item(i);
            var nodeName = item.nodeName;
            if (typeof (obj[nodeName]) == "undefined") {
                obj[nodeName] = xmlToJson(item);
            } else {
                if (typeof (obj[nodeName].push) == "undefined") {
                    var old = obj[nodeName];
                    obj[nodeName] = [];
                    obj[nodeName].push(old);
                }
                obj[nodeName].push(xmlToJson(item));
            }
        }
    }
    return obj;
};