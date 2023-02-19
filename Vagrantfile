# -*- mode: ruby -*-
# vi: set ft=ruby :

$ssh_path = 'INSERT'
$digitalOceanToken = 'INSERT'
$ssh_key_name_on_digital_ocean = "INSERT"


Vagrant.configure("2") do |config|
  config.vm.box = 'digital_ocean'
  config.vm.box_url = "https://github.com/devopsgroup-io/vagrant-digitalocean/raw/master/box/digital_ocean.box"
  config.ssh.private_key_path = $ssh_path
  config.vm.synced_folder ".", "/vagrant", type: "rsync"

  config.vm.define "minitwit", primary: true do |server|
    server.vm.provider :digital_ocean do |provider|
      provider.token = $digitalOceanToken
      provider.ssh_key_name = $ssh_key_name_on_digital_ocean
      provider.image = 'ubuntu-22-04-x64'
      provider.region = 'fra1'
      provider.size = 's-1vcpu-1gb'
      provider.privatenetworking = true
    end

    server.vm.hostname = "minitwit"

    server.vm.provision "shell", inline: <<-SHELL
      echo "Installing docker"
      sudo apt update
      sudo apt-get update
      sudo apt-get remove docker docker-engine containerd runc
      sudo apt-get install docker.io
      sudo apt-get -y install docker-compose
      sudo apt-get update


      cp -r /vagrant/* $HOME

      docker-compose up



    SHELL
  end


  config.vm.provision "shell", privileged: false, inline: <<-SHELL
    sudo apt-get update
  SHELL
end