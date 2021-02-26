<template>
    <div id="menu">
        <div class="menu__logo">
            <div class="logo"></div>
            <div class="title">Khoản thu</div>
            <div class="icon--bar"></div>
        </div>
        <div class="menu__content">
            <router-link v-for="item in $store.state.menuTab" :key="item.id" :to="{name: item.id}" :class="{item: true, 'item--current': item.id===$route.name}">
                <div :class="'item__icon ' + item.icon"></div>
                <div class="item__text">{{item.name}}</div>
            </router-link>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
        }
    },
    methods: {
        setCurrentTab(newTab) {
            this.$store.commit('setCurrentTab', newTab);
        }
    },
    mounted() {
        this.$store.commit('setCurrentTab', this.$route.name);
    },
    updated() {
        this.$store.commit('setCurrentTab', this.$route.name);
    }
}
</script>
<style scoped>
#menu {
    position: absolute;
    top: 0;
    left: 0;
    width: 205px;
    height: 100%;
    background-color: #24394B;
    color: #fff;
}

.menu__logo {
    display: flex;
    width: 100%;
    height: 50px;
    align-items: center;
    overflow: hidden;
}

    .menu__logo .logo {
        width: 34px;
        height: 34px;
        background: url('../../assets/ImagesIcons/ic_KhoanThu_56.svg') no-repeat center;
        margin-left: 12px;
        margin-right: 8px;
    }

    .menu__logo .title {
        width: calc(100% - 26px - 34px - 20px - 20px);
        overflow: hidden;
        font-family: 'OpenSans-Bold';
        font-size: 15px;
    }

    .menu__logo .icon--bar {
        width: 26px;
        height: 26px;
        background: url('../../assets/ImagesIcons/ic_sprites2.png') no-repeat 3px 3px;
        margin-right: 12px;
        margin-left: 8px;
    }
.menu__content {
    width: 100%;
    height: calc(100vh - 50px - 3px);
    border-top: 3px solid #223147;
    overflow-y: auto;
    color: #E9EBEE;
}

    .menu__content .item {
        display: flex;
        width: 100%;
        height: 46px;
        border-bottom: 2px solid #24394B;
        border-top: 2px solid #24394B;
        overflow: hidden;
        align-items: center;
        color: #E9EBEE;
        text-decoration: none;
        cursor: pointer;
    }

        .menu__content .item:hover{
           background-color: #404F64;
        }

        .menu__content .item .item__icon{
           width: 30px;
           height: 30px;
           margin-left: 12px;
           margin-right: 8px;
        }

    .menu__content .item.item--current {
        background-color: #404F64;
        border-left: 3px solid #0DD469;
        color: #0DD469;
        width: calc(100% - 3px);
    }

        .menu__content .item.item--current .item__icon{
           margin-left: 9px;
        }
</style>