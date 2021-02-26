<template>
    <div id="header">
        <div class="item float--left header__title">
            <div class="title__text">
                {{$store.state.menuTab.find(tab => tab.id === $route.name)? 
                $store.state.menuTab.find(tab => tab.id === $route.name).name:""}}</div>
            <div class="title__icon"></div>
        </div>
        <div class="item float--right">
            <div class="account icon-avatar"></div>
        </div>
        <div class="item float--right">
            <div class="search icon-search"></div>
        </div>
        <div class="item float--right">
            <select class="year m-select">
                <option class="m-option">2020-2021</option>
                <option class="m-option">2019-2020</option>
                <option class="m-option">2018-2019</option>
            </select>
        </div>
        <div class="item float--right m-flex">
            <div class="home m-flex">
                <div class="icon icon-home"></div>
                <div class="text">Trường mẫu giáo Edu platform 1</div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    
}
</script>
<style scoped>
#header {
    position: absolute;
    top: 0;
    left: 205px;
    right: 0;
    width: calc(100% - 205px);
    height: 50px;
    overflow: hidden;
    box-shadow: 0 3px #E9E9E9;
    z-index: 2;
}

.item {
    height: 100%;
    display: flex;
    align-items: center;
}

.header__title {
    font-family: 'OpenSans-Bold';
    font-size: 15px;
    margin-left: 20px;
}

    .header__title .title__icon {
        width: 20px;
        height: 20px;
        margin-left: 8px;
        margin-right: 12px;
        background: url('../../assets/ImagesIcons/ic_sprites2.png') no-repeat -911px -47px;
    }

    .item .account {
        width: 42px;
        height: 42px;
        margin-right: 10px;
        padding: 4px;
        cursor: pointer;
    }

    .item .search {
        width: 36px;
        height: 36px;
        margin: 0 12px 0 12px;
        cursor: pointer;
    }

    .item .year {
        margin-right: 10px;
    }

    .item .home {
        height: 32px;
        width: 300px;
        display: flex;
        align-items: center;
        margin: 0 8px 0 8px;
    }

        .item .home .icon{
            height: 30px;
            width: 30px;
            border: 1px solid #0FA655;
            border-radius: 4px;
            cursor: pointer;
        }

        .item .home .text{
            height: 30px;
            width: calc(100% - 32px - 1px);
            border: 1px solid #cccccc;
            border-left: none;
            padding: 0 8px 0 12px;
            border-radius: 4px;
            display: flex;
            align-items: center;
        }
</style>