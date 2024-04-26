    def repeat_x_infinite1 (img, x, y, z, img_width)
        img.draw(x, y, z)
        if x <= 0
            repeat_x_infinite1(img, x + img_width, y, z, img_width)
        end
    end
