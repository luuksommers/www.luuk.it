for %i in (*.jpg) do jpegtran -copy none -optimize -outfile "%i" "%i"
for %i in (*.png) do pngout "%i"