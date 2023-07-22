function bsNavClick(url) {window.location.href = url;}
function bsNavOver(divObj) {divObj.className = divObj.className + 'Over';}
function bsNavOut(divObj) {divObj.className = divObj.className.substr(0, divObj.className.length - 4);}
/* from shop, here because of php5. */
function bs_ss_toggleDiversity(imgElm, id) {
	//try {
		var doShow = true;
		//var elms = document.getElementsByTagName('tr');
		var elms = document.getElementsByTagName('td');
		var compareKey = id + '_';
		for (var i=0; i<elms.length; i++) {
			if (elms[i]['id'].substr(0, compareKey.length) == compareKey) {
				elms[i].style.display = (elms[i].style.display == 'none') ? '' : 'none';
				if (elms[i].style.display != 'none') doShow = false;
			}
		}
		imgElm.src = '/_bsImages/applications/smartshop/cart/viola/' + ((doShow) ? 'show' : 'hide') + 'Diversity.gif';
	/*
	} catch (e) {
		alert(e);
		//never mind, old browser or so.
	}
	*/
}