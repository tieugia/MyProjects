String.prototype.format = function (a) {
    console.log(a);
    //g => global
    //m => match
    //i => index
    return this.replace(/{(\d+)}/g, (m, i) => {
        //console.log(m);
        //console.log(i);
        return a[i];
    });
}