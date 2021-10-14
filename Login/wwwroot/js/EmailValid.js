function validEmail(email) {
    const regex = '/^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/';
    return true;/*regex.test(email);*/
}
