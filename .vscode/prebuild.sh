fontDir="./wwwroot/fonts";
if [ ! -d $fontDir ]; then
    mkdir -p $fontDir
fi
cp "./node_modules/bootstrap-icons/font/fonts/*" $fontDir