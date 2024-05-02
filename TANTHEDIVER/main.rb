require 'rubygems'
require 'gosu'

module ZOrder
    BACKGROUND, MIDDLE, ONMIDDLE, TOP = *0..3
end

class Object
    def member_of? container
      container.include? self
    end
end

class Game < Gosu::Window
    def initialize
      super 1000, 750
      self.caption = "THE TURTLE COLLECTOR"
    #Background
      @ocean_bg1 = Gosu::Image.new("media/far.png", :tileable => true)
      @ocean_bg2 = Gosu::Image.new("media/sand.png", :tileable => true)
      @foreground = Gosu::Image.new("media/mergedForeground.png", :tileable => true)

      @foreground_x = 0 #This x value is used for the foreground, it moves the fastest
      @bg1_x = 0 #This x value is used for the furthest background, it moves the slowest
      @bg2_x = 0 #This x value is used for the middle background, it moves at medium speed
      @y = 0

    #Startscreen and Losescreen
    @startScreen = Gosu::Image.new("media/startscreen.png", :tileable => true)
    @gameStart = false
    @startScreenZ = 3

    @loseScreen = Gosu::Image.new("media/losescreen.png", :tileable => true)
    @loseScreenZ = 0

    #Player
        @player_idle = Gosu::Image.load_tiles("media/player-idle.png", 160, 160)
        @player_swim = Gosu::Image.load_tiles("media/player-fast.png", 160, 160)
        @movementIndex = 0
        @playerX = 200
        @playerY = 350
        @playerMode = 0

        @health = 100
        @font = Gosu::Font.new(20)
      @small_font = Gosu::Font.new(15)

    
    #Turtle1
    @turtle_swim = Gosu::Image.load_tiles("media/2/Walk.png", 96, 96)
    @turtleX = rand(1000..1200)
    @turtleY = rand(0..750)
    @movementIndex2 = 0


    #Turtle2
    @turtleX2 = rand(1000..1200)
    @turtleY2 = rand(0..750)

    #Turtle3
    @turtleX3 = rand(1000..1200)
    @turtleY3 = rand(0..750)

    #Turtle4
    @turtleX4 = rand(1000..1200)
    @turtleY4 = rand(0..750)

    #Ca kiem
    @cakiem_swim = Gosu::Image.load_tiles("media/3/Walk.png", 200, 200)
    @cakiemX = rand(1000..1600)
    @cakiemY = rand(0..750)
    @movementIndex3 = 0 

    #Ca kiem2
    @cakiemX2 = rand(1000..1600)
    @cakiemY2 = rand(0..750)

    #Ca kiem3
    @cakiemX3 = rand(1000..1600)
    @cakiemY3 = rand(0..750)

    #Kraken 
    @kraken_swim = Gosu::Image.load_tiles("media/6/Walk.png", 325, 325)
    @krakenX = rand(1500..2000)
    @krakenY = rand(0..750)
    @movementIndex4 = 0 

    #kraken2
    @krakenX2 = rand(1500..2000)
    @krakenY2 = rand(0..750)

    end

    def update
    #For background to move
        @foreground_x -= 5

        @bg1_x -= 1
        @bg2_x -= 3

        
    #For player model to move 
        @movementIndex += 0.1

        if button_down?(Gosu::KbD) and !(@playerX > (1000-160))
            @playerX += 8
            @playerMode = 1
        end
        if button_down?(Gosu::KbA) && !(@playerX < 0)
            @playerX -= 5
            @playerMode = 0
            if button_down?(Gosu::KbD) then @playerMode = 1 end
        end
        if button_down?(Gosu::KbW) and (@playerY != 0)
            @playerY -= 5
            @playerMode = 0
            if button_down?(Gosu::KbD) then @playerMode = 1 end
        end 
        if button_down?(Gosu::KbS) and (@playerY != (750 - 160))
            @playerY += 5
            @playerMode = 0
            if button_down?(Gosu::KbD) then @playerMode = 1 end
        end 

        #For turtle1 to move
        @movementIndex2 += 0.1
        @turtleX -= 3.25
        @turtleX2 -= 3.5
        @turtleX3 -= 4
        @turtleX4 -= 3.75

        #For cakiem to move 
        @movementIndex3 += 0.1
        @cakiemX -= 5.5
        @cakiemX2 -= 6.25
        @cakiemX3 -= 6

        #For kraken to move
        @movementIndex4 += 0.1
        @krakenX -= 3
        @krakenX2 -= 2.75

        if @gameStart 
            #Detect if player hits the fish 
            #Turtle increase health
            if Gosu.distance(@turtleX+48, @turtleY+48, @playerX+80, @playerY+80) <= 125
                @health += 0.25
            end 
            if Gosu.distance(@turtleX2+48, @turtleY2+48, @playerX+80, @playerY+80) <= 125
                @health += 0.25
            end 
            if Gosu.distance(@turtleX3+48, @turtleY3+48, @playerX+80, @playerY+80) <= 125
                @health += 0.25
            end 

            #cakiem decrease health
            if Gosu.distance(@cakiemX+100, @cakiemY+100, @playerX+80, @playerY+80) <= 170
                @health -= 0.5
            end 
            if Gosu.distance(@cakiemX2+100, @cakiemY2+100, @playerX+80, @playerY+80) <= 170
                @health -= 0.5
            end 
            if Gosu.distance(@cakiemX3+100, @cakiemY3+100, @playerX+80, @playerY+80) <= 170
                @health -= 0.5
            end 

            #kraken decrease heath
            if Gosu.distance(@krakenX+162.5, @krakenY+162.5, @playerX+80, @playerY+80) <= 230
                @health -= 1
            end 
            if Gosu.distance(@krakenX2+162.5, @krakenY2+162.5, @playerX+80, @playerY+80) <= 230
                @health -= 1
            end 

            if @health <= 0
                @loseScreenZ = 3
                @gameStart = false
                puts @gameStart.to_s
            end 

            if @health >= 100
                @health = 100
            end 
        end
    end


    def turtle_animation(x, y, z) 
        if @movementIndex2 > 5 then @movementIndex2 = 0 end
        @turtle_swim[@movementIndex2].draw(x, y, z)

        if @turtleX < -100 
            @turtleX = rand(1000..1200)
            @turtleY = rand(0..750)
        end
    end

    def turtle_animation2(x, y, z) 
        if @movementIndex2 > 5 then @movementIndex2 = 0 end
        @turtle_swim[@movementIndex2].draw(x, y, z)

        if @turtleX2 < -100 
            @turtleX2 = rand(1000..1200)
            @turtleY2 = rand(0..750)
        end
    end

    def turtle_animation3(x, y, z) 
        if @movementIndex2 > 5 then @movementIndex2 = 0 end
        @turtle_swim[@movementIndex2].draw(x, y, z)

        if @turtleX3 < -100 
            @turtleX3 = rand(1000..1200)
            @turtleY3 = rand(0..750)
        end
    end

    def turtle_animation4(x, y, z) 
        if @movementIndex2 > 5 then @movementIndex2 = 0 end
        @turtle_swim[@movementIndex2].draw(x, y, z)

        if @turtleX4 < -100 
            @turtleX4 = rand(1000..1200)
            @turtleY4 = rand(0..750)
        end
    end

    def cakiem_animation(x, y, z) 
        if @movementIndex3 > 3 then @movementIndex3 = 0 end
        @cakiem_swim[@movementIndex3].draw(x, y, z)

        if @cakiemX < -250 
            @cakiemX = rand(1000..1600)
            @cakiemY = rand(0..750)
        end
    end

    def cakiem_animation2(x, y, z) 
        if @movementIndex3 > 3 then @movementIndex3 = 0 end
        @cakiem_swim[@movementIndex3].draw(x, y, z)

        if @cakiemX2 < -250
            @cakiemX2 = rand(1000..1600)
            @cakiemY2 = rand(0..750)
        end
    end

    def cakiem_animation3(x, y, z) 
        if @movementIndex3 > 3 then @movementIndex3 = 0 end
        @cakiem_swim[@movementIndex3].draw(x, y, z)

        if @cakiemX3 < -250
            @cakiemX3 = rand(1000..1600)
            @cakiemY3 = rand(0..750)
        end
    end

    def kraken_animation(x, y, z) 
        if @movementIndex4 > 5 then @movementIndex4 = 0 end
        @kraken_swim[@movementIndex4].draw(x, y, z)

        if @krakenX < -350
            @krakenX = rand(1500..2000)
            @krakenY = rand(0..750)
        end
    end

    def kraken_animation2(x, y, z) 
        if @movementIndex4 > 5 then @movementIndex4 = 0 end
        @kraken_swim[@movementIndex4].draw(x, y, z)

        if @krakenX2 < -350
            @krakenX2 = rand(1500..2000)
            @krakenY2 = rand(0..750)
        end
    end

    def player_animation (x, y, z) 
        case @playerMode
        when 1
            if @movementIndex > 4 then @movementIndex = 0 end
            @player_swim[@movementIndex].draw(x, y, z)
        when 0
            if @movementIndex > 5 then @movementIndex = 0 end
            @player_idle[@movementIndex].draw(x, y, z)
        end
    end 

    def repeat_x_infinite (img, x, y, z, img_width)
        img.draw(x, y, z)
        if x <= -(img_width/2)
            repeat_x_infinite(img, x + img_width, y, z, img_width)
        end
    end

    def repeat_x_infinite1 (img, x, y, z, img_width)
        img.draw(x, y, z)
        if x <= 0
            repeat_x_infinite1(img, x + img_width, y, z, img_width)
        end
    end

    def mouse_on_area(leftX, rightX, topY, bottomY)
        if ((mouse_x > leftX and mouse_x < rightX) and (mouse_y > topY and mouse_y < bottomY))
          true
        else
          false
        end
      end

    def button_down(id)
		case id
	    when Gosu::MsLeft
            if mouse_on_area(0, 1000, 0, 750)
                @gameStart = true
                @loseScreenZ = 0
                @health = 100
            end 
        end 
    end 

    def draw
        @startScreen.draw(0, 0, @startScreenZ)
        @loseScreen.draw(0, 0, @loseScreenZ)

        if @gameStart 
            @startScreenZ = 0
            repeat_x_infinite1(@ocean_bg1, @bg1_x, @y, ZOrder::BACKGROUND, 1000)
            repeat_x_infinite1(@ocean_bg2, @bg2_x, @y, ZOrder::BACKGROUND, 1000)
            repeat_x_infinite(@foreground, @foreground_x, @y, ZOrder::BACKGROUND, 2000)

            #health
            Gosu.draw_rect(25, 25, @health * 2, 50, Gosu::Color::RED, ZOrder::TOP,)
            @font.draw_text("Health: " + @health.to_s, 30, 50, ZOrder::TOP, 1.0, 1.0, Gosu::Color::BLACK)

            #Player
            player_animation(@playerX, @playerY, ZOrder::MIDDLE)

            #Turtle
            turtle_animation(@turtleX, @turtleY, ZOrder::ONMIDDLE)
            turtle_animation2(@turtleX2, @turtleY2, ZOrder::ONMIDDLE)
            turtle_animation3(@turtleX3, @turtleY3, ZOrder::ONMIDDLE)
            turtle_animation4(@turtleX4, @turtleY4, ZOrder::ONMIDDLE)
            #Cakiem 
            cakiem_animation(@cakiemX, @cakiemY, ZOrder::ONMIDDLE)
            cakiem_animation2(@cakiemX2, @cakiemY2, ZOrder::ONMIDDLE)
            cakiem_animation3(@cakiemX3, @cakiemY3, ZOrder::ONMIDDLE)
            #Kraken
            kraken_animation(@krakenX, @krakenY, ZOrder::TOP)
            kraken_animation2(@krakenX2, @krakenY2, ZOrder::ONMIDDLE)
        
        end
            

    end     
end


Game.new.show

