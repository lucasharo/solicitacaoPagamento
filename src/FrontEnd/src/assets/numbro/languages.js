/*!
 * numbro.js language configuration
 * language : Bulgarian
 * author : Tim McIntosh (StayinFront NZ)
 */
(function(){"use strict";var a={langLocaleCode:"bg",cultureCode:"bg",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"Ð˜",million:"Ð",billion:"M",trillion:"T"},ordinal:function(){return"."},currency:{symbol:"Ð»Ð².",code:"BGN"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&this.numbro.culture("bg",a)}).call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Czech
 * locale: Czech Republic
 * author : Jan Pesa : https://github.com/smajl (based on work from Anatoli Papirovski : https://github.com/apapirovski)
 */
function(){"use strict";var a={langLocaleCode:"cs-CZ",cultureCode:"cs-CZ",delimiters:{thousands:"Â ",decimal:","},abbreviations:{thousand:"tis.",million:"mil.",billion:"mld.",trillion:"bil."},ordinal:function(){return"."},currency:{symbol:"KÄ",position:"postfix",spaceSeparated:!0,code:"CZK"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Danish
 * locale: Denmark
 * author : Michael Storgaard : https://github.com/mstorgaard
 */
function(){"use strict";var a={langLocaleCode:"da-DK",cultureCode:"da-DK",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mio",billion:"mia",trillion:"b"},ordinal:function(){return"."},currency:{symbol:"kr",position:"postfix",code:"DKK"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : German
 * locale: Austria
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"de-AT",cultureCode:"de-AT",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"â‚¬",code:"EUR"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : German
 * locale: Switzerland
 * author : Michael Piefel : https://github.com/piefel (based on work from Marco Krage : https://github.com/sinky)
 */
function(){"use strict";var a={langLocaleCode:"de-CH",cultureCode:"de-CH",delimiters:{thousands:"'",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"CHF",position:"postfix",code:"CHF"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : German
 * locale: Germany
 * author : Marco Krage : https://github.com/sinky
 *
 * Generally useful in Germany, Austria, Luxembourg, Belgium
 */
function(){"use strict";var a={langLocaleCode:"de-DE",cultureCode:"de-DE",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"â‚¬",position:"postfix",spaceSeparated:!0,code:"EUR"},defaults:{currencyFormat:",4"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : German
 * locale: Liechtenstein
 * author : Michael Piefel : https://github.com/piefel (based on work from Marco Krage : https://github.com/sinky)
 */
function(){"use strict";var a={langLocaleCode:"de-LI",cultureCode:"de-LI",delimiters:{thousands:"'",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"CHF",position:"postfix",code:"CHF"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Greek (el)
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"el",cultureCode:"el",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"Ï‡",million:"Îµ",billion:"Î´",trillion:"Ï„"},ordinal:function(){return"."},currency:{symbol:"â‚¬",code:"EUR"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("el",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : English
 * locale: Australia
 * author : Benedikt Huss : https://github.com/ben305
 */
function(){"use strict";var a={langLocaleCode:"en-AU",cultureCode:"en-AU",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"$",position:"prefix",code:"AUD"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : English
 * locale: United Kingdom of Great Britain and Northern Ireland
 * author : Dan Ristic : https://github.com/dristic
 */
function(){"use strict";var a={langLocaleCode:"en-GB",cultureCode:"en-GB",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"Â£",position:"prefix",code:"GBP"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
+ * numbro.js language configuration
 * language : English
 * locale: Ireland
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"en-IE",cultureCode:"en-IE",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"â‚¬",code:"EUR"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("en-gb",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : English
 * locale: New Zealand
 * author : Benedikt Huss : https://github.com/ben305
 */
function(){"use strict";var a={langLocaleCode:"en-NZ",cultureCode:"en-NZ",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"$",position:"prefix",code:"NZD"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : English
 * locale: South Africa
 * author : Stewart Scott https://github.com/stewart42
 */
function(){"use strict";var a={langLocaleCode:"en-ZA",cultureCode:"en-ZA",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"R",position:"prefix",code:"ZAR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Argentina
 * author : Hernan Garcia : https://github.com/hgarcia
 */
function(){"use strict";var a={langLocaleCode:"es-AR",cultureCode:"es-AR",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"$",position:"postfix",code:"ARS"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Chile
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-CL",cultureCode:"es-CL",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"$",position:"prefix",code:"CLP"},defaults:{currencyFormat:"$0,0"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Colombia
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-CO",cultureCode:"es-CO",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Costa Rica
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-CR",cultureCode:"es-CR",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"â‚¡",position:"postfix",code:"CRC"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Spain
 * author : Hernan Garcia : https://github.com/hgarcia
 */
function(){"use strict";var a={langLocaleCode:"es-ES",cultureCode:"es-ES",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Mexico
 * author : Joe Bordes : https://github.com/joebordes
 */
function(){"use strict";var a={langLocaleCode:"es-MX",cultureCode:"es-MX",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"$",position:"postfix",code:"MXN"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Nicaragua
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-NI",cultureCode:"es-NI",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"C$",position:"prefix",code:"NIO"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Peru
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-PE",cultureCode:"es-PE",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"S/.",position:"prefix",code:"PEN"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: Puerto Rico
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-PR",cultureCode:"es-PR",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"$",position:"prefix",code:"USD"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Spanish
 * locale: El Salvador
 * author : Gwyn Judd : https://github.com/gwynjudd
 */
function(){"use strict";var a={langLocaleCode:"es-SV",cultureCode:"es-SV",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"mm",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===b||3===b?"er":2===b?"do":7===b||0===b?"mo":8===b?"vo":9===b?"no":"to"},currency:{symbol:"$",position:"prefix",code:"SVC"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Estonian
 * locale: Estonia
 * author : Illimar Tambek : https://github.com/ragulka
 *
 * Note: in Estonian, abbreviations are always separated
 * from numbers with a space
 */
function(){"use strict";var a={langLocaleCode:"et-EE",cultureCode:"et-EE",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:" tuh",million:" mln",billion:" mld",trillion:" trl"},ordinal:function(){return"."},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Farsi
 * locale: Iran
 * author : neo13 : https://github.com/neo13
 */
function(){"use strict";var a={langLocaleCode:"fa-IR",cultureCode:"fa-IR",delimiters:{thousands:"ØŒ",decimal:"."},abbreviations:{thousand:"Ù‡Ø²Ø§Ø±",million:"Ù…ÛŒÙ„ÛŒÙˆÙ†",billion:"Ù…ÛŒÙ„ÛŒØ§Ø±Ø¯",trillion:"ØªØ±ÛŒÙ„ÛŒÙˆÙ†"},ordinal:function(){return"Ø§Ù…"},currency:{symbol:"ï·¼",code:"IRR"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Finnish
 * locale: Finland
 * author : Sami Saada : https://github.com/samitheberber
 */
function(){"use strict";var a={langLocaleCode:"fi-FI",cultureCode:"fi-FI",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"M",billion:"G",trillion:"T"},ordinal:function(){return"."},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Filipino (Pilipino)
 * locale: Philippines
 * author : Michael Abadilla : https://github.com/mjmaix
 */
function(){"use strict";var a={langLocaleCode:"fil-PH",cultureCode:"fil-PH",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){var b=a%10;return 1===~~(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th"},currency:{symbol:"â‚±",code:"PHP"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : French
 * locale: Canada
 * author : LÃ©o Renaud-Allaire : https://github.com/renaudleo
 */
function(){"use strict";var a={langLocaleCode:"fr-CA",cultureCode:"fr-CA",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"M",billion:"G",trillion:"T"},ordinal:function(a){return 1===a?"er":"Ã¨me"},currency:{symbol:"$",position:"postfix",spaceSeparated:!0,code:"USD"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : French
 * locale: Switzerland
 * author : Adam Draper : https://github.com/adamwdraper
 */
function(){"use strict";var a={langLocaleCode:"fr-CH",cultureCode:"fr-CH",delimiters:{thousands:" ",decimal:"."},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){return 1===a?"er":"Ã¨me"},currency:{symbol:"CHF",position:"postfix",code:"CHF"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : French
 * locale: France
 * author : Adam Draper : https://github.com/adamwdraper
 */
function(){"use strict";var a={langLocaleCode:"fr-FR",cultureCode:"fr-FR",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(a){return 1===a?"er":"Ã¨me"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Hebrew
 * locale : IL
 * author : Eli Zehavi : https://github.com/eli-zehavi
 */
function(){"use strict";var a={langLocaleCode:"he-IL",cultureCode:"he-IL",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"××œ×£",million:"×ž×œ×™×•×Ÿ",billion:"×‘×œ×™×•×Ÿ",trillion:"×˜×¨×™×œ×™×•×Ÿ"},currency:{symbol:"â‚ª",position:"prefix",code:"ILS"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"â‚ª ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"â‚ª ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Hungarian
 * locale: Hungary
 * author : Peter Bakondy : https://github.com/pbakondy
 */
function(){"use strict";var a={langLocaleCode:"hu-HU",cultureCode:"hu-HU",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"E",// ezer
million:"M",// milliÃ³
billion:"Mrd",// milliÃ¡rd
trillion:"T"},ordinal:function(){return"."},currency:{symbol:" Ft",position:"postfix",code:"HUF"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Indonesian
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"id",cultureCode:"id",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"r",million:"j",billion:"m",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"Rp",code:"IDR"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("id",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Italian
 * locale: Switzerland
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"it-CH",cultureCode:"it-CH",delimiters:{thousands:"'",decimal:"."},abbreviations:{thousand:"mila",million:"mil",billion:"b",trillion:"t"},ordinal:function(){return"Â°"},currency:{symbol:"CHF",code:"CHF"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("it-CH",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Italian
 * locale: Italy
 * author : Giacomo Trombi : http://cinquepunti.it
 */
function(){"use strict";var a={langLocaleCode:"it-IT",cultureCode:"it-IT",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"mila",million:"mil",billion:"b",trillion:"t"},ordinal:function(){return"Âº"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Japanese
 * locale: Japan
 * author : teppeis : https://github.com/teppeis
 */
function(){"use strict";var a={langLocaleCode:"ja-JP",cultureCode:"ja-JP",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"åƒ",million:"ç™¾ä¸‡",billion:"åå„„",trillion:"å…†"},ordinal:function(){return"."},currency:{symbol:"Â¥",position:"prefix",code:"JPY"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Korean
 * author (numbro.js Version): Randy Wilander : https://github.com/rocketedaway
 * author (numeral.js Version) : Rich Daley : https://github.com/pedantic-git
 */
function(){"use strict";var a={langLocaleCode:"ko-KR",cultureCode:"ko-KR",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"ì²œ",million:"ë°±ë§Œ",billion:"ì‹­ì–µ",trillion:"ì¼ì¡°"},ordinal:function(){return"."},currency:{symbol:"â‚©",code:"KPW"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Latvian
 * locale: Latvia
 * author : Lauris BukÅ¡is-Haberkorns : https://github.com/Lafriks
 */
function(){"use strict";var a={langLocaleCode:"lv-LV",cultureCode:"lv-LV",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:" tÅ«kst.",million:" milj.",billion:" mljrd.",trillion:" trilj."},ordinal:function(){return"."},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language: Norwegian BokmÃ¥l
 * locale: Norway
 * author : Benjamin Van Ryseghem
 */
function(){"use strict";var a={langLocaleCode:"nb-NO",cultureCode:"nb-NO",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"t",million:"M",billion:"md",trillion:"t"},currency:{symbol:"kr",position:"postfix",code:"NOK"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Norwegian BokmÃ¥l (nb)
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"nb",cultureCode:"nb",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"t",million:"mil",billion:"mia",trillion:"b"},ordinal:function(){return"."},currency:{symbol:"kr",code:"NOK"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("nb",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Dutch
 * locale: Belgium
 * author : Dieter Luypaert : https://github.com/moeriki
 */
function(){"use strict";var a={langLocaleCode:"nl-BE",cultureCode:"nl-BE",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"mln",billion:"mld",trillion:"bln"},ordinal:function(a){var b=a%100;return 0!==a&&b<=1||8===b||b>=20?"ste":"de"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Dutch
 * locale: Netherlands
 * author : Dave Clayton : https://github.com/davedx
 */
function(){"use strict";var a={langLocaleCode:"nl-NL",cultureCode:"nl-NL",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"k",million:"mln",billion:"mrd",trillion:"bln"},ordinal:function(a){var b=a%100;return 0!==a&&b<=1||8===b||b>=20?"ste":"de"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Norwegian Nynorsk (nn)
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"nn",cultureCode:"nn",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"t",million:"mil",billion:"mia",trillion:"b"},ordinal:function(){return"."},currency:{symbol:"kr",code:"NOK"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.language&&window.numbro.language("nn",a)}(),/*!
 * numbro.js language configuration
 * language : Polish
 * locale : Poland
 * author : Dominik Bulaj : https://github.com/dominikbulaj
 */
function(){"use strict";var a={langLocaleCode:"pl-PL",cultureCode:"pl-PL",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"tys.",million:"mln",billion:"mld",trillion:"bln"},ordinal:function(){return"."},currency:{symbol:" zÅ‚",position:"postfix",code:"PLN"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Portuguese
 * locale : Brazil
 * author : Ramiro Varandas Jr : https://github.com/ramirovjr
 */
function(){"use strict";var a={langLocaleCode:"pt-BR",cultureCode:"pt-BR",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"mil",million:"milhÃµes",billion:"b",trillion:"t"},ordinal:function(){return"Âº"},currency:{symbol:"R$",position:"prefix",code:"BRL"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Portuguese
 * locale : Portugal
 * author : Diogo Resende : https://github.com/dresende
 */
function(){"use strict";var a={langLocaleCode:"pt-PT",cultureCode:"pt-PT",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"k",million:"m",billion:"b",trillion:"t"},ordinal:function(){return"Âº"},currency:{symbol:"â‚¬",position:"postfix",code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numeral.js language configuration
 * language : Romanian
 * author : Andrei Alecu https://github.com/andreialecu
 */
function(){"use strict";var a={langLocaleCode:"ro-RO",cultureCode:"ro-RO",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"mii",million:"mil",billion:"mld",trillion:"bln"},ordinal:function(){return"."},currency:{symbol:" lei",position:"postfix",code:"RON"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Romanian (ro)
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"ro",cultureCode:"ro",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"mie",million:"mln",billion:"mld",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"RON",code:"RON"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("ro",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Russian
 * locale : Russsia
 * author : Anatoli Papirovski : https://github.com/apapirovski
 */
function(){"use strict";var a={langLocaleCode:"ru-RU",cultureCode:"ru-RU",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"Ñ‚Ñ‹Ñ.",million:"Ð¼Ð»Ð½",billion:"b",trillion:"t"},ordinal:function(){
// not ideal, but since in Russian it can taken on
// different forms (masculine, feminine, neuter)
// this is all we can do
return"."},currency:{symbol:"Ñ€ÑƒÐ±.",position:"postfix",code:"RUB"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Russian
 * locale : Ukraine
 * author : Anatoli Papirovski : https://github.com/apapirovski
 */
function(){"use strict";var a={langLocaleCode:"ru-UA",cultureCode:"ru-UA",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"Ñ‚Ñ‹Ñ.",million:"Ð¼Ð»Ð½",billion:"b",trillion:"t"},ordinal:function(){
// not ideal, but since in Russian it can taken on
// different forms (masculine, feminine, neuter)
// this is all we can do
return"."},currency:{symbol:"â‚´",position:"postfix",code:"UAH"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Slovak
 * locale : Slovakia
 * author : Jan Pesa : https://github.com/smajl (based on work from Ahmed Al Hafoudh : http://www.freevision.sk)
 */
function(){"use strict";var a={langLocaleCode:"sk-SK",cultureCode:"sk-SK",delimiters:{thousands:"Â ",decimal:","},abbreviations:{thousand:"tis.",million:"mil.",billion:"mld.",trillion:"bil."},ordinal:function(){return"."},currency:{symbol:"â‚¬",position:"postfix",spaceSeparated:!0,code:"EUR"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Slovene
 * locale: Slovenia
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"sl",cultureCode:"sl",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"tis.",million:"mil.",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"â‚¬",code:"EUR"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("sl",a)}(),/*!
 * numbro.js language configuration
 * language : Serbian (sr)
 * country : Serbia (Cyrillic)
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"sr-Cyrl-RS",cultureCode:"sr-Cyrl-RS",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"Ñ‚Ñ‹Ñ.",million:"Ð¼Ð»Ð½",billion:"b",trillion:"t"},ordinal:function(){return"."},currency:{symbol:"RSD",code:"RSD"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("sr-Cyrl-RS",a)}(),/*!
 * numbro.js language configuration
 * language : Swedish
 * locale : Sweden
 * author : Benjamin Van Ryseghem (benjamin.vanryseghem.com)
 */
function(){"use strict";var a={langLocaleCode:"sv-SE",cultureCode:"sv-SE",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"t",million:"M",billion:"md",trillion:"tmd"},currency:{symbol:"kr",position:"postfix",code:"SEK"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Thai
 * locale : Thailand
 * author : Sathit Jittanupat : https://github.com/jojosati
 */
function(){"use strict";var a={langLocaleCode:"th-TH",cultureCode:"th-TH",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"à¸žà¸±à¸™",million:"à¸¥à¹‰à¸²à¸™",billion:"à¸žà¸±à¸™à¸¥à¹‰à¸²à¸™",trillion:"à¸¥à¹‰à¸²à¸™à¸¥à¹‰à¸²à¸™"},ordinal:function(){return"."},currency:{symbol:"à¸¿",position:"postfix",code:"THB"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Turkish
 * locale : Turkey
 * author : Ecmel Ercan : https://github.com/ecmel,
 *          Erhan Gundogan : https://github.com/erhangundogan,
 *          Burak YiÄŸit Kaya: https://github.com/BYK
 */
function(){"use strict";var a={1:"'inci",5:"'inci",8:"'inci",70:"'inci",80:"'inci",2:"'nci",7:"'nci",20:"'nci",50:"'nci",3:"'Ã¼ncÃ¼",4:"'Ã¼ncÃ¼",100:"'Ã¼ncÃ¼",6:"'ncÄ±",9:"'uncu",10:"'uncu",30:"'uncu",60:"'Ä±ncÄ±",90:"'Ä±ncÄ±"},b={langLocaleCode:"tr-TR",cultureCode:"tr-TR",delimiters:{thousands:".",decimal:","},abbreviations:{thousand:"bin",million:"milyon",billion:"milyar",trillion:"trilyon"},ordinal:function(b){if(0===b)// special case for zero
return"'Ä±ncÄ±";var c=b%10,d=b%100-c,e=b>=100?100:null;return a[c]||a[d]||a[e]},currency:{symbol:"â‚º",position:"postfix",code:"TRY"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=b),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(b.cultureCode,b)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Ukrainian
 * locale : Ukraine
 * author : Michael Piefel : https://github.com/piefel (with help from Tetyana Kuzmenko)
 */
function(){"use strict";var a={langLocaleCode:"uk-UA",cultureCode:"uk-UA",delimiters:{thousands:" ",decimal:","},abbreviations:{thousand:"Ñ‚Ð¸Ñ.",million:"Ð¼Ð»Ð½",billion:"Ð¼Ð»Ñ€Ð´",trillion:"Ð±Ð»Ð½"},ordinal:function(){
// not ideal, but since in Ukrainian it can taken on
// different forms (masculine, feminine, neuter)
// this is all we can do
return""},currency:{symbol:"â‚´",position:"postfix",code:"UAH"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:",0.00 $",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:",0 $"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : simplified chinese
 * locale : China
 * author : badplum : https://github.com/badplum
 */
function(){"use strict";var a={langLocaleCode:"zh-CN",cultureCode:"zh-CN",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"åƒ",million:"ç™¾ä¸‡",billion:"åäº¿",trillion:"å…†"},ordinal:function(){return"."},currency:{symbol:"Â¥",position:"prefix",code:"CNY"},defaults:{currencyFormat:",4 a"},formats:{fourDigits:"4 a",fullWithTwoDecimals:"$ ,0.00",fullWithTwoDecimalsNoCurrency:",0.00",fullWithNoDecimals:"$ ,0"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Chinese traditional
 * locale: Macau
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"zh-MO",cultureCode:"zh-MO",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"åƒ",million:"ç™¾è¬",billion:"åå„„",trillion:"å…†"},ordinal:function(){return"."},currency:{symbol:"MOP",code:"MOP"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("zh-MO",a)}(),/*!
 * numbro.js language configuration
 * language : Chinese simplified
 * locale: Singapore
 * author : Tim McIntosh (StayinFront NZ)
 */
function(){"use strict";var a={langLocaleCode:"zh-SG",cultureCode:"zh-SG",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"åƒ",million:"ç™¾ä¸‡",billion:"åäº¿",trillion:"å…†"},ordinal:function(){return"."},currency:{symbol:"$",code:"SGD"}};
// Node
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture("zh-SG",a)}.call("undefined"==typeof window?this:window),/*!
 * numbro.js language configuration
 * language : Chinese (Taiwan)
 * author (numbro.js Version): Randy Wilander : https://github.com/rocketedaway
 * author (numeral.js Version) : Rich Daley : https://github.com/pedantic-git
 */
function(){"use strict";var a={langLocaleCode:"zh-TW",cultureCode:"zh-TW",delimiters:{thousands:",",decimal:"."},abbreviations:{thousand:"åƒ",million:"ç™¾è¬",billion:"åå„„",trillion:"å…†"},ordinal:function(){return"ç¬¬"},currency:{symbol:"NT$",code:"TWD"}};
// CommonJS
"undefined"!=typeof module&&module.exports&&(module.exports=a),
// Browser
"undefined"!=typeof window&&window.numbro&&window.numbro.culture&&window.numbro.culture(a.cultureCode,a)}.call("undefined"==typeof window?this:window);