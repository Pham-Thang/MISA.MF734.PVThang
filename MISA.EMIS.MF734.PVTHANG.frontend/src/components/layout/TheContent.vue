<template>
    <div id="content">
        <router-view></router-view>
    </div>
</template>
<script>
// import FeeList from '../../views/planning/FeeList'

export default {
    components: {
        
    }
}
</script>
<style>
#content {
    position: absolute;
    top: 50px;
    left: 205px;
    right: 0;
    bottom: 0;
    width: calc(100% - 205px);
    height: calc(100vh - 50px);
}
</style>